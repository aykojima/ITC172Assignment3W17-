<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 34px;
        }
        .auto-style2 {
            height: 124px;
            margin-top: 0px;
        }
        .auto-style3 {
            width: 78px;
        }
        .auto-style4 {
            height: 34px;
            width: 78px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Classic ADO</h1>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">Email: </td>
                <td>
                    <asp:TextBox ID="EmailTextBox" runat="server" Height="25px" Width="196px"></asp:TextBox>

                </td>
            </tr>
             <tr>
                <td class="auto-style3">Password</td>
                <td>
                    <asp:TextBox ID="PasswordTextBox" runat="server" 
                        TextMode="Password" Height="25px" Width="197px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Button ID="LoginButton" runat="server" Text="Log in" OnClick="LoginButton_Click" />

                </td>
                <td class="auto-style1">
                    <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>

                </td>
            </tr>

        </table>
    
    </div>
    </form>
</body>
</html>
