<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminDashboard.aspx.cs" Inherits="_370Resturants.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Admin Dashboard<br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Logout" Width="250px" />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Click to add a new Resturant" Width="250px" />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Click to edit the Resturants Info" Width="250px" />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Click to view/edit the Resturant Menus" Width="250px" />
            <br />
            <br />
            Things to do<br />
            *edit resturants info<br />
            *fix edit part of resturants, doesnt seem to save edit atm<br />
            *view/edit resturant menu<br />
            **Add edit/delete functionality to edit resturant menu items<br />
            ***add variables to keep track of old item name/category/price1 upon button click for sqlquery<br />
            **Editing resturantsinfo<br />
            *MainSearch<br />
            **Learn how to intergrate datalist header with dropdownlist, dropdownlist will have all categories and itembody will have all menuitems in that list<br />
            <asp:Label ID="Label1" runat="server" Text="List of Resturants &amp; Info"></asp:Label>
            <br />
            <asp:DataList ID="DataList1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyField="rName" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Both">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="White" />
                <ItemTemplate>
                    Name:
                    <asp:Label ID="rNameLabel" runat="server" Text='<%# Eval("rName") %>' />
                    <br />
                    Location:
                    <asp:Label ID="rXLabel" runat="server" Text='<%# Eval("rX") %>' />
                    ,
                    <asp:Label ID="rYLabel" runat="server" Text='<%# Eval("rY") %>' />
                    <br />
                    Desc:
                    <asp:Label ID="rDescLabel" runat="server" Text='<%# Eval("rDesc") %>' />
                    <br />
                    Hours:
                    <asp:Label ID="rOpeningHoursLabel" runat="server" Text='<%# Eval("rOpeningHours") %>' />
                    &nbsp;-
                    <asp:Label ID="rClosingHoursLabel" runat="server" Text='<%# Eval("rClosingHours") %>' />
                    <br />
                    Days Open:
                    <asp:Label ID="rDaysOpenLabel" runat="server" Text='<%# Eval("rDaysOpen") %>' />
                    <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:DataList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ResturantsInfoWebsiteLogin %>" SelectCommand="SELECT [rName], [rX], [rY], [rDesc], [rOpeningHours], [rClosingHours], [rDaysOpen] FROM [resturantsInfo] ORDER BY [rName]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
