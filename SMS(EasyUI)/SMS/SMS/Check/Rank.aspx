<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rank.aspx.cs" Inherits="SMS.Check.Rank" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商品销售排行</title>
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
                url: 'RankData.ashx',
                rownumbers: true,
                singleSelect: true,
                pagination: true,
                pageSize: 10,
                pageList: [10],
                columns: [[
                    { field: 'RankNum', title: '排名', align: 'center', width: 100 },
                    { field: 'CommodityName', title: '商品名称', align: 'center', width: 100 },
                    { field: 'CompanyName', title: '供应商', align: 'center', width: 100 },
                    { field: 'id', title: '商品编号', align: 'center', width: 100 },
                    { field: 'Unit', title: '单位', align: 'center', width: 100 },
                    { field: 'TotalCount', title: '销售数量', align: 'center', width: 100 },
                ]],
                toolbar: [{
                    text: '<a   class="easyui-linkbutton" onclick="Export(\'销售排行表\', $(\'#table\'));">导出</a>'
                }]
            })

        })
    </script>
</head>
<body>
    <table id="table"></table>
</body>
</html>
