<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMenus.aspx.cs" Inherits="_370Resturants.EditMenus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Edit the Resturants here, or go back to the <a href="adminDashboard.aspx">Admin Dashboard</a> when done:<br />
            Name, Category, and Price1 are required, PriceDesc is used to show text like Small, Large, 16oz, etc.<br />
            Character Limits are 50 characters, Price limit is 9999.99<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Not Selected Yet"></asp:Label>
            <hr />
            Select the Resturant<br />
            <asp:DropDownList ID="DropDownList1" runat="server" OnTextChanged="DropDownList1_TextChanged" AutoPostBack="True">
            </asp:DropDownList>
&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Item to Resturant" />
            <br />
            Item Name: <asp:TextBox ID="TextBox1" runat="server" Width="155px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Item Category:
            <asp:TextBox ID="TextBox2" runat="server" Width="155px"></asp:TextBox>
            <br />
            Item Description:
            <asp:TextBox ID="TextBox3" runat="server" Width="400px"></asp:TextBox>
            <br />
            Price1:
            <asp:TextBox ID="TextBox4" runat="server" Width="50px"></asp:TextBox>
&nbsp;&nbsp; Price1Desc:
            <asp:TextBox ID="TextBox5" runat="server" Width="50px"></asp:TextBox>
&nbsp;&nbsp; Price2:
            <asp:TextBox ID="TextBox6" runat="server" Width="50px"></asp:TextBox>
&nbsp;&nbsp; Price2Desc:
            <asp:TextBox ID="TextBox7" runat="server" Width="50px"></asp:TextBox>
            <br />
            Price3:
            <asp:TextBox ID="TextBox8" runat="server" Width="50px"></asp:TextBox>
&nbsp;&nbsp; Price3Desc:
            <asp:TextBox ID="TextBox9" runat="server" Width="50px"></asp:TextBox>
&nbsp;&nbsp; Price4:
            <asp:TextBox ID="TextBox10" runat="server" Width="50px"></asp:TextBox>
&nbsp;&nbsp; Price4Desc:
            <asp:TextBox ID="TextBox11" runat="server" Width="50px"></asp:TextBox>
&nbsp;
            <br />
            Price5:
            <asp:TextBox ID="TextBox12" runat="server" Width="50px"></asp:TextBox>
&nbsp;&nbsp; Price5Desc:
            <asp:TextBox ID="TextBox13" runat="server" Width="50px"></asp:TextBox>
            <br />
            <asp:DataList ID="DataList1" runat="server" BorderColor="Blue" BorderWidth="2px" GridLines="Both">
                <ItemTemplate>
                    Category:
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                    &nbsp;| ItemName:
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="EDIT" />
                    <br />
                    Description:
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("ItemDesc") %>'></asp:Label>
                    <br />
                    Price1:&nbsp;
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Price1") %>'></asp:Label>
                    &nbsp;&nbsp;Price1Desc:
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Price1Desc") %>'></asp:Label>
                    &nbsp;| Price2:&nbsp;
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Price2") %>'></asp:Label>
                    &nbsp; Price2Desc:
                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Price2Desc") %>'></asp:Label>
                    &nbsp;| Price3:&nbsp;
                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("Price3") %>'></asp:Label>
                    &nbsp;&nbsp;Price3Desc:
                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("Price3Desc") %>'></asp:Label>
                    <br />
                    Price4:&nbsp;
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("Price4") %>'></asp:Label>
                    &nbsp; Price4Desc:
                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("Price4Desc") %>'></asp:Label>
                    &nbsp;| Price5:&nbsp;
                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("Price5") %>'></asp:Label>
                    &nbsp; Price5Desc:
                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("Price5Desc") %>'></asp:Label>
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ResturantsInfoWebsiteLogin %>" SelectCommand="SELECT [Category], [ItemName], [ItemDesc], [ItemPrice1], [ItemPriceDesc1], [ItemPrice2], [ItemPriceDesc2], [ItemPrice3], [ItemPriceDesc3], [ItemPrice4], [ItemPriceDesc4], [ItemPrice5], [ItemPriceDesc5] FROM [resturantMenu] ORDER BY [Category]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ResturantsInfoWebsiteLogin %>" SelectCommand="SELECT DISTINCT [rName] FROM [resturantsInfo] ORDER BY [rName]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
