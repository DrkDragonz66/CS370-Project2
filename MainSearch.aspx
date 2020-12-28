<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainSearch.aspx.cs" Inherits="_370Resturants.MainSearch" %>

<!DOCTYPE html>
<link rel="stylesheet" href="MainSearchStyle.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>

    <form id="form1" runat="server">

    <div class="row">
        <div class="column left" style="background-color: #aaa;">
            <h2>Column 1</h2>
            <asp:Label ID="Label1" runat="server" Text="Temp"></asp:Label>
            <p>Enter your location here:<br />
                X:
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />Y:
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="175px" OnClick="Button1_Click" />
                <br />
            </p>
            <asp:DataList ID="DataList1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyField="rName" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Both" OnItemCommand="DataList1_ItemCommand">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="White" />
                <ItemTemplate>
                    <asp:Label ID="rNameLabel" runat="server" Text='<%# Eval("rName") %>' />
                    <br />
                    <asp:Label ID="rXLabel" runat="server" Text='<%# Eval("rX") %>' />
                    ,
                    <asp:Label ID="rYLabel" runat="server" Text='<%# Eval("rY") %>' />
                    <br />
                    <asp:Label ID="rDescLabel" runat="server" Text='<%# Eval("rDesc") %>' />
                    <br />
                    <asp:Label ID="rOpeningHoursLabel" runat="server" Text='<%# Eval("rOpeningHours") %>'></asp:Label>
                    &nbsp;-
                    <asp:Label ID="rClosingHoursLabel" runat="server" Text='<%# Eval("rClosingHours") %>' />
                    <br />
                    <asp:Label ID="rDaysOpenLabel" runat="server" Text='<%# Eval("rDaysOpen") %>' />
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Select" />
                    <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ResturantsInfoWebsiteLogin %>" SelectCommand="SELECT [rName], [rX], [rY], [rDesc], [rOpeningHours], [rClosingHours], [rDaysOpen], [rDistance] FROM [resturantsInfo] ORDER BY [rName]"></asp:SqlDataSource>
        <asp:DataList ID="DataList4" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Both" OnItemCommand="DataList4_ItemCommand" Visible="False">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:Label ID="rNameLabel" runat="server" Text='<%# Eval("rName") %>' />
                <br />
                <asp:Label ID="rXLabel" runat="server" Text='<%# Eval("rX") %>' />
                ,
                <asp:Label ID="rYLabel" runat="server" Text='<%# Eval("rY") %>' />
                <br />
                <asp:Label ID="rDescLabel" runat="server" Text='<%# Eval("rDesc") %>' />
                <br />
                <asp:Label ID="rDistance" runat="server" Text='<%# Eval("rDistance") %>'></asp:Label>
                &nbsp;away<br />
                <asp:Label ID="rOpeningHoursLabel" runat="server" Text='<%# Eval("rOpeningHours") %>' />
                &nbsp;-
                <asp:Label ID="rClosingHoursLabel" runat="server" Text='<%# Eval("rClosingHours") %>' />
                <br />
                <asp:Label ID="rDaysOpenLabel" runat="server" Text='<%# Eval("rDaysOpen") %>' />
                <br />
                <asp:Button ID="Button3" runat="server" Text="Select" />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
        
        </div>
        <div class="column right" style="background-color: #bbb;">
            <asp:TextBox ID="TextBox3" runat="server">Username</asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server">Password</asp:TextBox>
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" style="text-align: right" Text="Login" />
            <h2>Column 2</h2>
            <asp:DataList ID="DataList3" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Both" RepeatColumns="4" RepeatDirection="Horizontal" Width="828px">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="Category" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                    <br />
                    <asp:Label ID="ItemName" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Description" runat="server" Text='<%# Eval("ItemDesc") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Price1" runat="server" Text='<%# Eval("Price1") %>'></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="Price1Desc" runat="server" Text='<%# Eval("Price1Desc") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Price2" runat="server" Text='<%# Eval("Price2") %>'></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="Price2Desc" runat="server" Text='<%# Eval("Price2Desc") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Price3" runat="server" Text='<%# Eval("Price3") %>'></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="Price3Desc" runat="server" Text='<%# Eval("Price3Desc") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Price4" runat="server" Text='<%# Eval("Price4") %>'></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="Price4Desc" runat="server" Text='<%# Eval("Price4Desc") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Price5" runat="server" Text='<%# Eval("Price5") %>'></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="Price5Desc" runat="server" Text='<%# Eval("Price5Desc") %>'></asp:Label>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:DataList>

            
        </div>
        
        
        
    </div>



    </form>



</body>
</html>
