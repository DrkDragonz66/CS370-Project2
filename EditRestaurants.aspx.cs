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
    public partial class EditResturant : System.Web.UI.Page
    {
        String OldName = "", OldX = "", OldY = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillList();
            }         
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkValues())
            {
                SqlConnection resturantDB = new SqlConnection("Server=tcp:resturantsinfo.database.windows.net,1433;Initial Catalog=ResturantsInfo;Persist Security Info=False;User ID=website;Password=335Z!+jUY=anH9f-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                resturantDB.Open();
                


                Boolean dupe = false;
                SqlCommand getData = new SqlCommand("SELECT * FROM resturantsinfo WHERE rName = @name AND rX = @x AND rY = @y", resturantDB);
                getData.Parameters.AddWithValue("@name", TextBox1.Text);
                getData.Parameters.AddWithValue("@x", TextBox2.Text);
                getData.Parameters.AddWithValue("@y", TextBox3.Text);
                SqlDataReader dr = getData.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["rName"].ToString().Equals(TextBox1.Text) || dr["rX"].ToString().Equals(TextBox2.Text) || dr["rY"].ToString().Equals(TextBox3.Text))
                        dupe = true;
                }
                dr.Close();
                if (dupe)
                {
                    resturantDB.Close();
                    Label1.Text = "Resturant with the same name and location already exists";
                }
                else
                {
                    SqlCommand update = new SqlCommand("UPDATE resturantsInfo SET rName = '@name', rX = @x, rY = @y, rDesc = '@desc', rOpeningHours = '@openhours', rClosingHours = '@closinghours' WHERE rName = '@oldname' AND rX = @oldx AND rY = @oldy", resturantDB);
                    update.Parameters.AddWithValue("@name", TextBox1.Text);
                    update.Parameters.AddWithValue("@x", TextBox2.Text);
                    update.Parameters.AddWithValue("@y", TextBox3.Text);
                    update.Parameters.AddWithValue("@desc", TextBox4.Text);
                    update.Parameters.AddWithValue("@openhours", TextBox5.Text);
                    update.Parameters.AddWithValue("@closinghours", TextBox6.Text);
                    update.Parameters.AddWithValue("@oldname", OldName);
                    update.Parameters.AddWithValue("@oldx", OldX);
                    update.Parameters.AddWithValue("@oldy", OldY);
                    update.ExecuteNonQuery();
                    SqlCommand update2 = new SqlCommand("UPDATE resturantsMenu SET MenuName = '@name' WHERE MenuName = '@oldName'", resturantDB);
                    update2.Parameters.AddWithValue("@name", TextBox1.Text);
                    update2.Parameters.AddWithValue("@oldname", OldName);
                    update2.ExecuteNonQuery();

                    //franchise section
                    if (CheckBox1.Checked)
                    {
                        SqlCommand franchise = new SqlCommand("UPDATE dbo.resturantsInfo SET rFranchise = 1 WHERE rName = @name AND rX = @x AND rY = @y", resturantDB);
                        franchise.Parameters.AddWithValue("@name", TextBox1.Text);
                        franchise.Parameters.AddWithValue("@x", TextBox2.Text);
                        franchise.Parameters.AddWithValue("@y", TextBox3.Text);
                        franchise.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand franchise = new SqlCommand("UPDATE dbo.resturantsInfo SET rFranchise = 0 WHERE rName = @name AND rX = @x AND rY = @y", resturantDB);
                        franchise.Parameters.AddWithValue("@name", TextBox1.Text);
                        franchise.Parameters.AddWithValue("@x", TextBox2.Text);
                        franchise.Parameters.AddWithValue("@y", TextBox3.Text);
                        franchise.ExecuteNonQuery();
                    }

                    //days section
                    SqlCommand setDaysOpenText = new SqlCommand("UPDATE dbo.resturantsInfo SET rDaysOpen = @DaysOpen WHERE rName = @name AND rX = @x AND rY = @y", resturantDB);
                    SqlCommand setDays = new SqlCommand("UPDATE dbo.resturantsInfo SET rSunday = @sun, rMonday = @mon, rTuesday = @tues, rWednesday = @wed, rThursday = @thur, rFriday = @fri, rSaturday = @sat WHERE rName = @name AND rX = @x AND rY = @y", resturantDB);
                    String DaysOpen = "";
                    int[] days = new int[] { 0, 0, 0, 0, 0, 0, 0 };

                    ListItem li = CheckBoxList1.Items.FindByValue("Sunday");
                    if (li.Selected)
                    {
                        DaysOpen += "Sun";
                        days[0] = 1;
                    }
                    li = CheckBoxList1.Items.FindByValue("Monday");

                    if (li.Selected)
                    {
                        DaysOpen += "Mon";
                        days[1] = 1;
                    }
                    li = CheckBoxList1.Items.FindByValue("Tuesday");
                    if (li.Selected)
                    {
                        DaysOpen += "Tues";
                        days[2] = 1;
                    }
                    li = CheckBoxList1.Items.FindByValue("Wednesday");
                    if (li.Selected)
                    {
                        DaysOpen += "Wed";
                        days[3] = 1;
                    }
                    li = CheckBoxList1.Items.FindByValue("Thursday");
                    if (li.Selected)
                    {
                        DaysOpen += "Thurs";
                        days[4] = 1;
                    }
                    li = CheckBoxList1.Items.FindByValue("Friday");
                    if (li.Selected)
                    {
                        DaysOpen += "Fri";
                        days[5] = 1;
                    }
                    li = CheckBoxList1.Items.FindByValue("Saturday");
                    if (li.Selected)
                    {
                        DaysOpen += "Sat";
                        days[6] = 1;
                    }


                    setDays.Parameters.AddWithValue("@name", TextBox1.Text);
                    setDays.Parameters.AddWithValue("@x", TextBox2.Text);
                    setDays.Parameters.AddWithValue("@y", TextBox3.Text);
                    setDays.Parameters.AddWithValue("@sun", days[0]);
                    setDays.Parameters.AddWithValue("@mon", days[1]);
                    setDays.Parameters.AddWithValue("@tues", days[2]);
                    setDays.Parameters.AddWithValue("@wed", days[3]);
                    setDays.Parameters.AddWithValue("@thur", days[4]);
                    setDays.Parameters.AddWithValue("@fri", days[5]);
                    setDays.Parameters.AddWithValue("@sat", days[6]);
                    setDays.ExecuteNonQuery();

                    setDaysOpenText.Parameters.AddWithValue("@name", TextBox1.Text);
                    setDaysOpenText.Parameters.AddWithValue("@x", TextBox2.Text);
                    setDaysOpenText.Parameters.AddWithValue("@y", TextBox3.Text);
                    setDaysOpenText.Parameters.AddWithValue("@DaysOpen", DaysOpen);
                    setDaysOpenText.ExecuteNonQuery();


                    OldName = TextBox1.Text;
                    OldX = TextBox2.Text;
                    OldY = TextBox3.Text;

                    Label1.Text = "Update submitted for " + TextBox1.Text;
                    resturantDB.Close();
                }
            }
        }

        private Boolean checkValues()
        {
            Boolean result = true;
            int temp = 0;
            Label1.Text = "Please try again, here are the errors: ";

            if (String.IsNullOrEmpty(TextBox1.Text))
            {
                Label1.Text += "Empty Resturant Name. ";
                result = false;
            }
            else
            {
                if (TextBox1.Text.Length > 50)
                {
                    Label1.Text += "Resturant Name is bigger than 50 characters. ";
                    result = false;
                }
            }

            if (String.IsNullOrEmpty(TextBox2.Text))
            {
                Label1.Text += "Empty X Location. ";
                result = false;
            }
            else if (Int32.TryParse(TextBox2.Text, out temp))
            {
                if (temp < 0 || temp > 100)
                {
                    Label1.Text += "X is not between 0 and 100. ";
                    result = false;
                }
            }
            else
            {
                Label1.Text += "X is not a number. ";
                result = false;
            }

            if (String.IsNullOrEmpty(TextBox3.Text))
            {
                Label1.Text += "Empty Y Location. ";
                result = false;
            }
            else if (Int32.TryParse(TextBox3.Text, out temp))
            {
                if (temp < 0 || temp > 100)
                {
                    Label1.Text += "Y is not between 0 and 100. ";
                    result = false;
                }
            }
            else
            {
                Label1.Text += "Y is not a number. ";
                result = false;
            }

            if (!String.IsNullOrEmpty(TextBox4.Text))
            {
                if (TextBox1.Text.Length > 50)
                {
                    Label1.Text += "Description is bigger than 50 characters. ";
                    result = false;
                }
            }

            if (String.IsNullOrEmpty(TextBox5.Text))
            {
                Label1.Text += "Empty Opening Hours. ";
                result = false;
            }
            else
            {
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM)";
                if (!Regex.IsMatch(TextBox5.Text, pattern, RegexOptions.CultureInvariant))
                {
                    Label1.Text += "Not a valid time format ('hh:mm AM|PM') in opening hours. ";
                    result = false;
                }
            }

            if (String.IsNullOrEmpty(TextBox6.Text))
            {
                Label1.Text += "Empty Closing Hours. ";
                result = false;
            }
            else
            {
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM)";
                if (!Regex.IsMatch(TextBox6.Text, pattern, RegexOptions.CultureInvariant))
                {
                    Label1.Text += "Not a valid time format ('hh:mm AM|PM') in closing hours. ";
                    result = false;
                }
            }
            return result;
        }

        private void FillList()
        {
            SqlConnection resturantDB = new SqlConnection("Server=tcp:resturantsinfo.database.windows.net,1433;Initial Catalog=ResturantsInfo;Persist Security Info=False;User ID=website;Password=335Z!+jUY=anH9f-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            resturantDB.Open();

            SqlCommand cmdFill = new SqlCommand("SELECT rName + ' (' + cast(rX as varchar(4)) + cast(',' as varchar(1)) + cast(rY as varchar(4)) + cast(')' as varchar(1)) as FullResturant, rID FROM [resturantsInfo] ORDER BY [rName]", resturantDB);
            SqlDataAdapter daFill = new SqlDataAdapter(cmdFill);
            DataSet ds = new DataSet();
            daFill.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "FullResturant";
            DropDownList1.DataValueField = "rID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select the resturant to edit"));

            resturantDB.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                if (TextBox7.Text.Equals("I want to delete this"))
                {
                    //delete
                }
                else
                {
                    Button2.Text = "FINAL WARNING TO DELETE RESTURANT";
                    TextBox7.Visible = true;
                    Label1.Text = "Please enter \"I want to delete this\" in the textbox and click the button again to confirm.";
                }
            }
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text.Equals("Select the resturant to edit"))
            {
                Button2.Visible = false;
                TextBox7.Visible = false;
                CheckBox2.Visible = false;
                Label1.Text = "Not Submitted Yet.";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                CheckBox1.Checked = false;
                ListItem li = CheckBoxList1.Items.FindByValue("Sunday");
                li.Selected = false;
                li = CheckBoxList1.Items.FindByValue("Monday");
                li.Selected = false;
                li = CheckBoxList1.Items.FindByValue("Tuesday");
                li.Selected = false;
                li = CheckBoxList1.Items.FindByValue("Wednesday");
                li.Selected = false;
                li = CheckBoxList1.Items.FindByValue("Thursday");
                li.Selected = false;
                li = CheckBoxList1.Items.FindByValue("Friday");
                li.Selected = false;
                li = CheckBoxList1.Items.FindByValue("Saturday");
                li.Selected = false;
            }
            else
            {
                Button2.Text = "CHECK BOX AND CLICK TO DELETE RESTURANT";
                TextBox7.Text = "";
                CheckBox2.Checked = false;
                Button2.Visible = true;
                TextBox7.Visible = false;
                CheckBox2.Visible = true;

                SqlConnection resturantDB = new SqlConnection("Server=tcp:resturantsinfo.database.windows.net,1433;Initial Catalog=ResturantsInfo;Persist Security Info=False;User ID=website;Password=335Z!+jUY=anH9f-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                resturantDB.Open();

                Label1.Text = "Not Submitted Yet, selected: " + DropDownList1.SelectedItem.Text + " WITH UniqueID:" + DropDownList1.SelectedItem.Value;

                SqlCommand getData = new SqlCommand("SELECT * FROM resturantsinfo WHERE rID = @id", resturantDB);
                getData.Parameters.AddWithValue("@id", DropDownList1.SelectedItem.Value);
                SqlDataReader dr = getData.ExecuteReader();
                if (dr.Read())
                {
                    TextBox1.Text = dr["rName"].ToString();
                    TextBox2.Text = dr["rX"].ToString();
                    TextBox3.Text = dr["rY"].ToString();
                    TextBox4.Text = dr["rDesc"].ToString();
                    TextBox5.Text = dr["rOpeningHours"].ToString();
                    TextBox6.Text = dr["rClosingHours"].ToString();

                    OldName = dr["rName"].ToString();
                    OldX = dr["rX"].ToString();
                    OldY = dr["rY"].ToString();

                    String test = dr["rFranchise"].ToString();
                    Boolean value = convertToBoolean(test);
                    if (value)
                        CheckBox1.Checked = true;
                    else
                        CheckBox1.Checked = false;

                    bool[] days = new bool[7];
                    days[0] = convertToBoolean(dr["rSunday"].ToString());
                    days[1] = convertToBoolean(dr["rMonday"].ToString());
                    days[2] = convertToBoolean(dr["rTuesday"].ToString());
                    days[3] = convertToBoolean(dr["rWednesday"].ToString());
                    days[4] = convertToBoolean(dr["rThursday"].ToString());
                    days[5] = convertToBoolean(dr["rFriday"].ToString());
                    days[6] = convertToBoolean(dr["rSaturday"].ToString());

                    ListItem li = CheckBoxList1.Items.FindByValue("Sunday");
                    li.Selected = days[0];
                    li = CheckBoxList1.Items.FindByValue("Monday");
                    li.Selected = days[1];
                    li = CheckBoxList1.Items.FindByValue("Tuesday");
                    li.Selected = days[2];
                    li = CheckBoxList1.Items.FindByValue("Wednesday");
                    li.Selected = days[3];
                    li = CheckBoxList1.Items.FindByValue("Thursday");
                    li.Selected = days[4];
                    li = CheckBoxList1.Items.FindByValue("Friday");
                    li.Selected = days[5];
                    li = CheckBoxList1.Items.FindByValue("Saturday");
                    li.Selected = days[6];

                    

                }
                resturantDB.Close();
            } //end else
        }// end DropDownList1_TextChanged

        private Boolean convertToBoolean(String test)
        {
            if (test.Equals("True"))
                return true;
            else
                return false;
        }
    }
}