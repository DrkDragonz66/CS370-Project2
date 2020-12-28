<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRestaurants.aspx.cs" Inherits="_370Resturants.EditResturant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            Edit the Resturants here, or go back to the <a href="adminDashboard.aspx">Admin Dashboard</a> when done:</div>
        Finish all inputs before clicking the button:&nbsp; <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save Changes" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Not Submitted Yet"></asp:Label>
        <hr />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnTextChanged="DropDownList1_TextChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ResturantsInfoWebsiteLogin %>" SelectCommand="SELECT [rName], [rX], [rY] FROM [resturantsInfo] ORDER BY [rName]"></asp:SqlDataSource>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="CHECK BOX AND CLICK TO DELETE RESTURANT" Visible="False" />
        <asp:CheckBox ID="CheckBox2" runat="server" Text=" " TextAlign="Left" Visible="False" />
        <asp:TextBox ID="TextBox7" runat="server" Visible="False" Width="348px"></asp:TextBox>
        <br />
        Resturant Name&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
        (required, 50 char max)<br />
        Resturant X Location&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        &nbsp;(required, between 0 and 100)<br />
        Resturant Y Location&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        &nbsp;(required, between 0 and 100)<br />
        Resturant Description&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        &nbsp;(not required, 100 char max)<br />
        Resturant Opening Hours&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        (required, hh:mm AM/PM format)<br />
        Resturant Closing Hours&nbsp;&nbsp;
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        (required, hh:mm AM/PM format)<br />
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Resturant Franchise" TextAlign="Left" />
        <br />
        Resturant Days Open<asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem>Sunday</asp:ListItem>
            <asp:ListItem>Monday</asp:ListItem>
            <asp:ListItem>Tuesday</asp:ListItem>
            <asp:ListItem>Wednesday</asp:ListItem>
            <asp:ListItem>Thursday</asp:ListItem>
            <asp:ListItem>Friday</asp:ListItem>
            <asp:ListItem>Saturday</asp:ListItem>
        </asp:CheckBoxList>
        <br />
    </form>
</body>
</html>
