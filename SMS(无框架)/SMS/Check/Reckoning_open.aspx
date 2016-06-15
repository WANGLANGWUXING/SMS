<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reckoning_open.aspx.cs" Inherits="SMS.Check.Reckoning_open" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="style/R_Global.css" rel="stylesheet" />
    <style type="text/css">
        .content {
            margin: auto;
        }

        table {
            width: 100%;
            text-align: center;
        }

        .input {
            width: 40%;
            height: 100%;
        }

        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <table>
                <thead>
                    <tr>
                        <td colspan="2">结账单</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>结款</td>
                        <td>
                            <%--<input class="input" type="number" />--%>
                            <asp:TextBox ID="Not" runat="server" CssClass="input" TextMode="Number" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>经手人</td>
                        <td>

                            <asp:TextBox ID="ManageMan" runat="server" CssClass="input"></asp:TextBox>
                    </tr>
                    <tr>
                        <td>结账日期</td>
                        <td>
                            <asp:TextBox ID="NowDate" runat="server" CssClass="input" Enabled="false"></asp:TextBox>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="ReckoningBtn" runat="server" Text="结账" OnClick="ReckoningBtn_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
