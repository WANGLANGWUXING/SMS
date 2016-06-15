<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stock_Search.aspx.cs" Inherits="SMS.Check.Stock_Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="style/R_Global.css" rel="stylesheet" />
    <style type="text/css">
        .content {
            margin: 2%;
        }

        .MenuTitle {
            text-align: center;
            margin: 2%;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <div class="MenuTitle">
                盘点管理->商品库存查询
            </div>
            <div>
                <table>
                    <thead>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CBCommodityName" runat="server" Text="商品名称" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtCommodityName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="CBCompanyName" runat="server" Text="供应商" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />
                            </td>
                        </tr>
                        <tr>
                            <th>商品名称</th>
                            <th>供应商</th>
                            <th>单位</th>
                            <th>进货数量</th>
                            <th>销售数量</th>
                            <th>库存</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptStock" runat="server" OnItemDataBound="rptStock_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("CommodityName") %></td>
                                    <td><%#Eval("CompanyName") %></td>
                                    <td><%#Eval("Unit")%></td>
                                    <td>
                                        <asp:HiddenField ID="StockId" runat="server" Value='<%#Eval("id") %>' />
                                        <asp:Label ID="StockCount" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="SellCount" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Stock" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
