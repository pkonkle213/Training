<%@ Page Title="ECTP Training" Language="C#" AutoEventWireup="true" CodeBehind="Training.aspx.cs" Inherits="TrainingApp.Training" %>

<%@ Register Src="~/WebUserControl1.ascx" TagName="CustomUserControl" TagPrefix="TCustomUserControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Training.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <table>
            <tr>
                <td colspan="2">Part 4 table</td>
            </tr>
            <tr>
                <td>Choose a category</td>
                <td>
                    <asp:DropDownList ID="DropCategory" runat="server" OnTextChanged="SetSubCategories" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Choose a subcategory</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropSubCategory" runat="server" OnTextChanged="SetCardsProducts" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="ProductGrid" runat="server" AutoGenerateColumns="false" DataKeyNames="ProductId" OnRowCommand="SelectProduct" OnSelectedIndexChanged="ProductGrid_SelectedIndexChanged">
                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Select" />
                            <asp:BoundField DataField="ProductName" HeaderText="Card Name" SortExpression="ProductName" />
                            <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color" />
                            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:C}" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <div id="ucdiv" runat="server" visible="false"  >
            <TCustomUserControl:CustomUserControl ID="uc" runat="server" />
        </div>
    </form>
</body>
</html>
