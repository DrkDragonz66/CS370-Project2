using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;

namespace _370Resturants
{
    public partial class EditMenus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillDropDown();
            }
            
        }
        public void fillDropDown()
        {
            SqlConnection resturantDB = new SqlConnection("Server=tcp:resturantsinfo.database.windows.net,1433;Initial Catalog=ResturantsInfo;Persist Security Info=False;User ID=website;Password=335Z!+jUY=anH9f-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            resturantDB.Open();

            SqlCommand cmdFill = new SqlCommand("SELECT DISTINCT rName FROM resturantsInfo ORDER BY rName", resturantDB);
            SqlDataAdapter daFill = new SqlDataAdapter(cmdFill);
            DataSet ds = new DataSet();
            daFill.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "rName";
            DropDownList1.DataValueField = "rName";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select the resturant to see/edit its menu"));

            resturantDB.Close();
        }

        public void fillMenuList()
        {
            SqlConnection resturantDB = new SqlConnection("Server=tcp:resturantsinfo.database.windows.net,1433;Initial Catalog=ResturantsInfo;Persist Security Info=False;User ID=website;Password=335Z!+jUY=anH9f-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            resturantDB.Open();
            String command = "";
            command = "SELECT * FROM resturantsMenu WHERE MenuName = '" + DropDownList1.SelectedItem.Text + "'";

            SqlDataAdapter da = new SqlDataAdapter(command, resturantDB);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataList1.DataSource = ds;
            DataList1.DataBind();


            resturantDB.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkValid())
            {
                SqlConnection resturantDB = new SqlConnection("Server=tcp:resturantsinfo.database.windows.net,1433;Initial Catalog=ResturantsInfo;Persist Security Info=False;User ID=website;Password=335Z!+jUY=anH9f-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                resturantDB.Open();
                String resturant = ""; String category = ""; String name = ""; String desc = "";
                double p1 = 0.0; String p1d = ""; double p2 = 0.0; String p2d = "";
                double p3 = 0.0; String p3d = ""; double p4 = 0.0; String p4d = "";
                double p5 = 0.0; String p5d = ""; 

                resturant = DropDownList1.SelectedItem.Text; category = TextBox2.Text; name = TextBox1.Text;
                String command = "INSERT INTO resturantsMenu (MenuName, Category, ItemName) VALUES ('" + resturant + "', '" + category + "', '" + name + "')";
                String command2 = " WHERE MenuName = '" + resturant + "' AND Category = '" + category + "' AND ItemName = '" + name + "'";
                SqlCommand addNewItem = new SqlCommand(command, resturantDB);
                addNewItem.ExecuteNonQuery();


                //description
                if (!String.IsNullOrEmpty(TextBox3.Text))
                    desc = TextBox3.Text;
                command = "UPDATE resturantsMenu SET ItemDesc = '" + desc + "'" + command2;
                SqlCommand updateItem = new SqlCommand(command, resturantDB);
                updateItem.ExecuteNonQuery();

                //price 1
                p1 = Double.Parse(TextBox4.Text);
                command = "UPDATE resturantsMenu SET Price1 = '" + p1 + "'" + command2;
                updateItem = new SqlCommand(command, resturantDB);
                updateItem.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(TextBox5.Text))
                    p1d = TextBox5.Text;
                command = "UPDATE resturantsMenu SET Price1Desc = '" + p1d + "'" + command2;
                updateItem = new SqlCommand(command, resturantDB);
                updateItem.ExecuteNonQuery();

                //price2
                if (String.IsNullOrEmpty(TextBox6.Text))
                    command = "UPDATE resturantsMenu SET Price2 = null " + command2;
                else
                {
                    p2 = Double.Parse(TextBox6.Text);
                    command = "UPDATE resturantsMenu SET Price2 = '" + p2 + "'" + command2;
                }
                updateItem = new SqlCommand(command, resturantDB);
                updateItem.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(TextBox7.Text))
                    p2d = TextBox7.Text;
                command = "UPDATE resturantsMenu SET Price2Desc = '" + p2d + "'" + command2;
                updateItem = new SqlCommand(command, resturantDB);
                updateItem.ExecuteNonQuery();


                //price3
                if (String.IsNullOrEmpty(TextBox8.Text))
                    command = "UPDATE resturantsMenu SET Price3 = null " + command2;
                else
                {
                    p3 = Double.Parse(TextBox8.Text);
                    command = "UPDATE resturantsMenu SET Price3 = '" + p3 + "'" + command2;
                }
                updateItem = new SqlCommand(command, resturantDB);
                updateItem.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(TextBox9.Text))
                    p3d = TextBox9.Text;
                command = "UPDATE resturantsMenu SET Price3Desc = '" + p3d + "'" + command2;
                updateItem = new SqlCommand(command, resturantDB);
                updateItem.ExecuteNonQuery();

                //price4
                if (String.IsNullOrEmpty(TextBox10.Text))
                    command = "UPDATE resturantsMenu SET Price4 = null " + command2;
                else
                {
                    p4 = Double.Parse(TextBox10.Text);
                    command = "UPDATE resturantsMenu SET Price4 = '" + p4 + "'" + command2;
                }
                updateItem = new SqlCommand(command, resturantDB);
                updateItem.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(TextBox11.Text))
                    p4d = TextBox11.Text;
                command = "UPDATE resturantsMenu SET Price4Desc = '" + p4d + "'" + command2;
                updateItem = new SqlCommand(command, resturantDB);
                updateItem.ExecuteNonQuery();

                //price5
                if (String.IsNullOrEmpty(TextBox12.Text))
                    command = "UPDATE resturantsMenu SET Price5 = null " + command2;
                else
                {
                    p5 = Double.Parse(TextBox12.Text);
                    command = "UPDATE resturantsMenu SET Price5 = '" + p5 + "'" + command2;
                }
                updateItem = new SqlCommand(command, resturantDB);
                updateItem.ExecuteNonQuery();

                if (!String.IsNullOrEmpty(TextBox13.Text))
                    p5d = TextBox13.Text;
                command = "UPDATE resturantsMenu SET Price4Desc = '" + p5d + "'" + command2;
                updateItem = new SqlCommand(command, resturantDB);
                updateItem.ExecuteNonQuery();

                String temp = "";
                temp += "Added to " + resturant + ", " + category + " - " + name + " (" + desc + ")";
                if (!TextBox4.Text.Equals(""))
                    temp += "With prices: " + TextBox5.Text + " " + TextBox4.Text;
                if (!TextBox6.Text.Equals(""))
                    temp += ", " + TextBox7.Text + " " + TextBox6.Text;
                if (!TextBox8.Text.Equals(""))
                    temp += ", " + TextBox9.Text + " " + TextBox8.Text;
                if (!TextBox10.Text.Equals(""))
                    temp += ", " + TextBox11.Text + " " + TextBox10.Text;
                if (!TextBox12.Text.Equals(""))
                    temp += ", " + TextBox13.Text + " " + TextBox12.Text;
                Label1.Text = temp;

                resturantDB.Close();

                fillMenuList();

            }
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            if (DropDownList1.SelectedItem.Text.Equals("Select the resturant to see/edit its menu"))
            {
                DataList1.Visible = false;
                Label1.Text = "Not Selected Yet.";
            }
            else
            {
                Label1.Text = DropDownList1.SelectedItem.Text;
                DataList1.Visible = true;
                fillMenuList();
            }
        }

        public Boolean checkValid()
        {
            Boolean result = true;
            double temp = 0;
            Label1.Text = "Please try again, here are the errors: ";

            if (String.IsNullOrEmpty(TextBox1.Text))
            {
                Label1.Text += "Empty Item Name. ";
                result = false;
            }
            else
            {
                if (TextBox1.Text.Length > 50)
                {
                    Label1.Text += "Item Name is bigger than 50 characters. ";
                    result = false;
                }
            }

            if (String.IsNullOrEmpty(TextBox2.Text))
            {
                Label1.Text += "Empty Category. ";
                result = false;
            }
            else
            {
                if (TextBox1.Text.Length > 50)
                {
                    Label1.Text += "Category is bigger than 50 characters. ";
                    result = false;
                }
            }

            if (TextBox3.Text.Length > 50)
            {
                Label1.Text += "Description is bigger than 50 characters. ";
                result = false;
            }

            if (String.IsNullOrEmpty(TextBox4.Text))
            {
                Label1.Text += "Empty Price 1. ";
                result = false;
            }
            else if (Double.TryParse(TextBox4.Text, out temp))
            {
                if (temp < 0 || temp > 9999.99)
                {
                    Label1.Text += "Price1 is not between 0 and 100. ";
                    result = false;
                }
            }
            if (TextBox5.Text.Length > 50)
            {
                Label1.Text += "Price1Desc is bigger than 50 characters. ";
                result = false;
            }
            /*
           if (Double.TryParse(TextBox4.Text, out temp))
            {
                if (temp < 0 || temp > 9999.99)
                {
                    Label1.Text += "Price1 is not between 0 and 100. ";
                    result = false;
                }
            }
            if (TextBox7.Text.Length > 50)
            {
                Label1.Text += "Price2Desc is bigger than 50 characters. ";
                result = false;
            }*/


            return result;
        }
    }
}