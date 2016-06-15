<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reckoning.aspx.cs" Inherits="SMS.Check.Reckoning" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="viewport" content="width=device-width,initial-scale-1,maximum-scale=1,user-scalable=no" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="HandheldFriendly" content="true" />
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
                盘点管理->货款结算管理：<asp:Label ID="type" runat="server" Text="进货信息结算"></asp:Label>
                <asp:Button ID="stockbtn" runat="server" Text="进货结算" OnClick="stockbtn_Click" />
                <asp:Button ID="returnbtn" runat="server" Text="退货结算" OnClick="returnbtn_Click" />
            </div>
            <div class="">
                <table>
                    <thead>
                        <tr>
                            <th>结款类型</th>
                            <th>商品名称</th>
                            <th>供应商</th>
                            <th>未付</th>
                            <th>结款次数</th>
                            <th>单据编号</th>
                            <th>结账</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptReckoning" runat="server" OnItemDataBound="rptReckoning_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("Type") %></td>
                                    <td><%#Eval("CommodityName") %></td>
                                    <td><%#Eval("CompanyName") %></td>
                                    <td>
                                        <asp:HiddenField ID="ReckoningID" runat="server" Value='<%#Eval("id") %>' />
                                        <asp:Label ID="ReckoningNot" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="ReckoningCount" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="ReceiptsId" runat="server"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btnReckoning" runat="server" Text="结账"></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="8" FirstPageText="首页" PrevPageText=""></webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
