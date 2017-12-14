<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstChallenge.aspx.cs" Inherits="MyFirstChallenge.FirstChallenge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        What is your age?&nbsp;
        <asp:TextBox ID="ageBox" runat="server"></asp:TextBox>
        <br />
        <br />
        How much money do you have in your pocket?&nbsp;
        <asp:TextBox ID="moneyBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="button" runat="server" Text="Click me to get your fortune!" OnClick="button_Click" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    </form>
</body>
</html>
