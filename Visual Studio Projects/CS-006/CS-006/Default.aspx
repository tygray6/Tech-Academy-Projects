﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_006.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: "Lucida Sans", "Lucida Sans Regular", "Lucida Grande", "Lucida Sans Unicode", Geneva, Verdana, sans-serif;
        }
        .auto-style2 {
            color: #FF0000;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <ol>
        <li>
            <form id="form1" runat="server">
                <div>
                    <h1>Head Line 1</h1>
                </div>
                <h2>Head Line 2</h2>
                <h3>Head Line 3</h3>
                <h4>Head Line 4</h4>
                <h5>Head Line 5</h5>
                <h6>Head Line 6</h6>
                <p class="auto-style1">
                    This is some text that I want to <span class="auto-style2">apply </span>a style to.</p>
                <p class="auto-style1">
                    &nbsp;</p>
                <p>
                    <a href="http://www.google.com">Add a hyperlink.</a></p>
                <p>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.microsoft.com" Target="_blank">This is another hyperlink</asp:HyperLink>
                </p>
                <p>
                    &nbsp;</p>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/2.png" />
                <br />
                <br />
                <table class="auto-style3">
                    <tr>
                        <td>Player</td>
                        <td>Year</td>
                        <td>Home Runs</td>
                    </tr>
                    <tr>
                        <td>Sammy Sosa</td>
                        <td>2005</td>
                        <td>100</td>
                    </tr>
                    <tr>
                        <td>Mark MacGuire</td>
                        <td>2005</td>
                        <td>102</td>
                    </tr>
                </table>
                <ol>
                    <li>First Item</li>
                </ol>
            </form>
        </li>
        <li>
            <p class="auto-style4">
                Second Item</p>
        </li>
        <li>
            <p class="auto-style4">
                Third Item</p>
        </li>
    </ol>
    <ul>
        <li>
            <p class="auto-style4">
                HI</p>
        </li>
        <li>
            <p class="auto-style4">
                this is</p>
        </li>
        <li>
            <p class="auto-style4">
                boring</p>
        </li>
    </ul>
</body>
</html>
