<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="M2MTransfer.aspx.cs" Inherits="LMLApp.UI.M2MTransfer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    Reciving ID</td>
                <td style="width:100px">
                    <asp:TextBox ID="txtRecivingID" runat="server"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="available "></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnCheckID" runat="server" Text="Check ID" />
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    Currant Balance</td>
                <td>
                    <asp:Label ID="lblCurrentBanalce" runat="server" Text="Balance"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Transfer Amount ($)</td>
                <td style="width:100px">
                    <asp:TextBox ID="txtTransferAmount" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Transfer PIN</td>
                <td style="width:100px">
                    <asp:TextBox ID="txtTransferPIN" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" Text="Send" 
                        Width="115px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
