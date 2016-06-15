<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesRanking.aspx.cs" Inherits="SMS.Check.SalesRanking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="style/R_Global.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="MenuTitle"> 盘点管理->商品销售排行</div>
        <div>
            <table>
                <thead>
                    <tr>
                        <th>排名</th>
                        <th>商品名称</th>
                        <th>供应商</th>
                        <th>单位</th>
                        <th>销售数量</th>
                    </tr>

                </thead>
                <tbody>
                    <asp:Repeater ID="rptRanking" runat="server" OnItemDataBound="rptRanking_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td><asp:Label ID="RankingID" runat="server"></asp:Label></td>
                                <td>
                                    <%#Eval("CommodityName") %>
                                </td>
                                <td><%#Eval("CompanyName") %></td>
                                <td><%#Eval("Unit") %></td>
                                <td>
                                    <asp:HiddenField ID="TotalId" runat="server" Value='<%#Eval("id") %>' />
                                    <asp:Label ID="total" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
