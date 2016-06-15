<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reckoning.aspx.cs" Inherits="SMS.Check.Reckoning" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>货款结算管理</title>
    <link href="../UI/themes/black/easyui.css" rel="stylesheet" />
    <link href="../UI/themes/icon.css" rel="stylesheet" />
    <script src="../Script/jquery-1.8.2.min.js"></script>
    <script src="../UI/jquery.easyui.min.js"></script>
    <script src="../UI/locale/easyui-lang-zh_CN.js"></script>
    <script src="export.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#table").datagrid({
                fit: true,
                fitColumns: true,
                striped: true,
                url: 'ReckoningData.ashx',
                rownumbers: true,
                singleSelect: true,
                pagination: true,
                pageSize: 10,
                pageList: [10],
                columns: [[
                    { field: 'Type', title: '结款类型', align: 'center', width: 100 },
                    { field: 'CommodityName', title: '商品名称', align: 'center', width: 100 },
                    { field: 'CompanyName', title: '供应商', align: 'center', width: 100 },
                    { field: 'NotPayment', title: '未付(金额)', align: 'center', width: 100, formatter: NotPaymentInfo },
                    { field: 'Count', title: '结款次数', align: 'center', width: 100 },
                    { field: 'ReckoningID', title: '单据编号', align: 'center', width: 100 },
                    { field: 'id', title: '库存编号', align: 'center', width: 100 },
                    { field: 'IsCheck', title: '结账', align: 'center', width: 100, formatter: settleAccounts }
                ]],
                toolbar: [{
                    text: '结账',
                    handler: function () {
                        var checkedItems = $("#table").datagrid("getChecked");
                        if (checkedItems.length > 0 && checkedItems[0].IsCheck == "结算") {
                            var NowDate = new Date();
                            $("#NotPayment").val(checkedItems[0].NotPayment);
                            $("#NowData").val(NowDate.toLocaleDateString());
                            $("#Reckoning_open").dialog({
                                width: 300,
                                height: 300,
                                modal: true,
                                title: '结账',
                                buttons: [{
                                    text: '结账',
                                    handler: function () {
                                        if ($("#ReckoningTable").form("validate")) {
                                            var NotPayment = $("#NotPayment").val();
                                            var NowData = $("#NowData").val();
                                            var ManageMan = $("#ManageMan").val();
                                            var CommodityId = checkedItems[0].id;
                                            $.ajax({
                                                type: 'post',
                                                dataType: 'html',
                                                url: 'Settle.ashx',
                                                data: {
                                                    NotPayment: NotPayment,
                                                    NowData: NowData,
                                                    ManageMan: ManageMan,
                                                    CommodityId: CommodityId,
                                                },
                                                success: function (data) {
                                                    if (data == "ok") {
                                                        $.messager.alert('提示', '结算成功');

                                                    }
                                                }
                                            })
                                        }
                                        $("#table").datagrid("reload");
                                        $("#Reckoning_open").dialog("closed");
                                    }
                                }]
                            })
                        } else {
                            $.messager.alert('提示', '未选择或已结算！');
                        }
                    }
                }, '-', {
                    text: '<select id="TypeCombobox"><option value="0">数据加载中……</option></select>'
                }, {
                    text: '<a class="easyui-linkbutton" onclick="Export(\'货款结算表\', $(\'#table\'));">导出</a>'
                }]
            });

            $("#TypeCombobox").combobox({
                width: 100,
                url: 'GetType.ashx',
                valueField: 'id',
                textField: 'type',
                editable: false,
                onLoadSuccess: function () {
                    $("#TypeCombobox").combobox("setValue", "0");
                },
                onSelect: function (rec) {
                    var text = $("#TypeCombobox").combobox("getText");

                    $('#table').datagrid("load", { type: text });
                }
            })
        });
        //结账
        function settleAccounts(value, row, index) {
            if (value == "结算") {
                return "未结算"
            }
            return "已结算";

        }
        //
        function Reckoning_open(row) {
            var NowDate = new Date();
            $("#NotPayment").val(row.NotPayment);
            $("#NowData").val(NowDate.toLocaleDateString());
            $("#Reckoning_open").dialog({
                width: 300,
                height: 300,
                modal: true

            })
        }
        //判断是否已结款
        function NotPaymentInfo(value, row, index) {
            if (value == "0" || value < 0) {
                return "已结款";
            }
            return value;
        }
    </script>
</head>
<body>

    <table id="table"></table>
    <div id="Reckoning_open">
        <table id="ReckoningTable">
            <tr>
                <td>结款</td>
                <td>
                    <input id="NotPayment" class="easyui-numberbox" data-options="required:true" /></td>
            </tr>
            <tr>
                <td>经手人</td>
                <td>
                    <input id="ManageMan" class="easyui-validatebox" data-options="required:true" /></td>
            </tr>
            <tr>
                <td>结账日期</td>
                <td>
                    <input id="NowData" class="easyui-validatebox" data-options="required:true" /></td>
            </tr>
        </table>
    </div>
    <div id="tool">
        类型： 
        <select id="TypeCombobox">
            <option value="0"></option>
        </select>
    </div>
    <div>
        <a class="easyui-linkbutton" onclick="Export('导出excel', $('#table'));">导出</a>
    </div>
</body>
</html>
