<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stock_Search.aspx.cs" Inherits="SMS.Check.Stock_Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商品库存查询</title>
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
                url: 'StockData.ashx',
                rownumbers: true,
                singleSelect: true,
                pagination: true,
                pageSize: 10,
                pageList: [10],
                columns: [[
                    { field: 'CommodityName', title: '商品名称', align: 'center', width: 100 },
                    { field: 'CompanyName', title: '供应商', align: 'center', width: 100 },
                    { field: 'Unit', title: '单位', align: 'center', width: 100 },
                    { field: 'id', title: '商品编号', align: 'center', width: 100 },
                    { field: 'StockCount', title: '进货数量', align: 'center', width: 100 },
                    { field: 'SellCount', title: '库存编号', align: 'center', width: 100 },
                    { field: 'Stock', title: '库存', align: 'center', width: 100 },
                ]],
                toolbar: '#tool'
            });
            $("#btnCommodityName").linkbutton({
                onClick: function () {
                    var CommodityName = $("#CommodityName").val().trim();
                    $('#table').datagrid({
                        queryParams: {
                            CommodityName: CommodityName
                        },
                        url: 'StockData.ashx',
                    });
                }
            });
            $("#btnCompanyName").linkbutton({
                onClick: function () {
                    var CompanyName = $("#CompanyName").val().trim();
                    $('#table').datagrid({
                        queryParams: {
                            CompanyName: CompanyName
                        },
                        url: 'StockData.ashx',
                    });
                }
            });

        })
    </script>
</head>
<body>
    <table id="table"></table>
    <div id="tool">
        商品名称：<input id="CommodityName" /><a id="btnCommodityName" href="#" class="easyui-linkbutton"">搜索</a>  
        供应商：<input id="CompanyName" /><a id="btnCompanyName" href="#" class="easyui-linkbutton"">搜索</a>  
                <a  class="easyui-linkbutton" onclick="Export('商品库存统计表', $('#table'));">导出</a>

    </div>
</body>
</html>
