<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DaySale.aspx.cs" Inherits="SMS.Check.DaySale" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>日销售额结算</title>
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
                url: 'DaySaleData.ashx',
                rownumbers: true,
                singleSelect: true,
                pagination: true,
                pageSize: 10,
                pageList: [10],
                columns: [[
                    { field: 'year', title: '年', align: 'center', width: 100 },
                    { field: 'month', title: '月', align: 'center', width: 100 },
                    { field: 'day', title: '日', align: 'center', width: 100 },
                    { field: 'salesum', title: '日销售额', align: 'center', width: 100 },
                ]],
                toolbar: [{
                    text: '<a class="easyui-linkbutton" onclick="Export(\'日销售额结算表\', $(\'#table\'));">导出</a>'

                }]
            })
        })
    </script>
</head>
<body>
    <table id="table"></table>
</body>
</html>
