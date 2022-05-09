<%@ Page Title="ECTP Training" Language="C#" AutoEventWireup="true" CodeBehind="Training.aspx.cs" Inherits="TrainingApp.Training" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Training.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="time" class="message" runat="server" Text="">
                <span id="timeHere" runat="server"></span>
            </asp:Label>
        </div>
        <div runat="server" id="Whateveryouwantto">
            <asp:Label ID="Label1" runat="server" Text="Data Entry"></asp:Label><br />
            <asp:TextBox ID="input" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Update" OnClick="NewLabel" />
            <asp:ListBox ID="Box1"></asp:ListBox>
        </div>
    </form>
</body>
</html>
