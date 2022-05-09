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
                            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <div id="ucdiv" runat="server" visible="false"  >
            <TCustomUserControl:CustomUserControl ID="uc" runat="server" />
        </div>
        <br />
        <table>
            <tr>
                <td colspan="2">Part 3 table
                    <tr>
                        <td>Pick a color</td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" OnTextChanged="SetProducts" AutoPostBack="true">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>Pick a product</td>
                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server" OnTextChanged="SetWorkOrders" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" AllowSorting="true" OnSorting="GridView1_Sorting">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                <Columns>
                                    <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:d}" SortExpression="StartDate" />
                                    <asp:BoundField DataField="DueDate" HeaderText="Due Date" DataFormatString="{0:d}" SortExpression="DueDate" />
                                    <asp:BoundField DataField="OrderQty" HeaderText="Quantity" DataFormatString="{0:d}" SortExpression="OrderQty" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
        </table>
    </form>
</body>
</html>
