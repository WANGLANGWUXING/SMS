<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stock_open.aspx.cs" Inherits="SMS.Check.Stock_open" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="style/R_Global.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="4" style="text-align: center">详细信息</td>
                </tr>
                <tr>
                    <td>单据编号</td>
                    <td colspan="3">
                        <asp:Label ID="ReceiptsId" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>商品名称</td>
                    <td colspan="3">
                        <asp:Label ID="CommodityName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>供 应 商</td>
                    <td colspan="3">
                        <asp:Label ID="CompanyName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>信息类型</td>
                    <td>
                        <asp:Label ID="Type" runat="server"></asp:Label>
                    </td>
                    <td>总金额</td>
                    <td>
                        <asp:Label ID="Total" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>数量</td>
                    <td>
                        <asp:Label ID="Number" runat="server"></asp:Label>
                    </td>
                    <td>价格</td>
                    <td>
                        <asp:Label ID="Pirce" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>进货日期</td>
                    <td colspan="3">
                        <asp:Label ID="StockDate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>经 手 人</td>
                    <td colspan="3">
                        <asp:Label ID="ManageMan" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>结算方式</td>
                    <td colspan="3">
                        <asp:Label ID="SettlementType" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>操 作 员</td>
                    <td colspan="3">
                        <asp:Label ID="Username" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>添加日期</td>
                    <td colspan="3">
                        <asp:Label ID="AddTime" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <input type="button" value="关闭" onclick="window.close()" />
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
