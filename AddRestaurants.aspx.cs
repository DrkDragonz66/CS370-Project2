using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace _370Resturants
{
    public partial class WebForm1 : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == true)
            {
                Label1.Text = "Successfully added";
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
                else {
                    SqlCommand insert = new SqlCommand("EXEC dbo.insertResturant @name, @x, @y, @desc, @openhours, @closinghours", resturantDB);
                    insert.Parameters.AddWithValue("@name", TextBox1.Text);
                    insert.Parameters.AddWithValue("@x", TextBox2.Text);
                    insert.Parameters.AddWithValue("@y", TextBox3.Text);
                    insert.Parameters.AddWithValue("@desc", TextBox4.Text);
                    insert.Parameters.AddWithValue("@openhours", TextBox5.Text);
                    insert.Parameters.AddWithValue("@closinghours", TextBox6.Text);
                    insert.ExecuteNonQuery();

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

                    resturantDB.Close();
                    Label1.Text = "Successfuly Added";
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
            Button1.Text = TextBox6.Text;
            return result;
        }
    }
}
