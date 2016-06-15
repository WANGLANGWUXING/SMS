<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DaySale.aspx.cs" Inherits="SMS.Check.DaySale" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="style/R_Global.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="MenuTitle">日销售额管理</div>
    <table>
        <thead>
            <tr>
                <th>年</th>
                <th>月</th>
                <th>日</th>
                <th>销售额</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptDaySale" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("year") %></td>
                        <td><%#Eval("month") %></td>
                        <td><%#Eval("day") %></td>
                        <td><%#Eval("salesum") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    </div>
    </form>
</body>
</html>
