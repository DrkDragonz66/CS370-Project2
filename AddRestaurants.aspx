<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRestaurants.aspx.cs" Inherits="_370Resturants.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divheader">
        Add a new resturant here, and go back to the <a href="adminDashboard.aspx">Admin Dashboard</a>  when done:
            <br />
            Finish all inputs before clicking the button:&nbsp; <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        
        <br />
        <asp:Label ID="Label1" runat="server" Text="Not Submitted Yet"></asp:Label>
            </div>
        <hr />
        Resturant Name&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        &nbsp; (required, 50 char max)<br />
        Resturant X Location&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        &nbsp;(required, between 0 and 100)<br />
        Resturant Y Location&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        &nbsp;(required, between 0 and 100)<br />
        Resturant Description&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        &nbsp;&nbsp;(not required, 100 char max)<br />
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
            </div>
    </form>
</body>
</html>
