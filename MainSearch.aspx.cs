using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace _370Resturants
{
    public partial class MainSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                setDefaultDistance();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Label1.Visible = true;
            DataList1.SelectedIndex = e.Item.ItemIndex;
            Label1.Text = ((Label)DataList1.SelectedItem.FindControl("rNameLabel")).Text;
            fillMenuList();

        }

        public void fillMenuList()
        {
            fillMenuCategoryDropDownList();


            SqlConnection resturantDB = new SqlConnection("Server=tcp:resturantsinfo.database.windows.net,1433;Initial Catalog=ResturantsInfo;Persist Security Info=False;User ID=website;Password=335Z!+jUY=anH9f-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            resturantDB.Open();
            String command = "";
            command = "SELECT * FROM resturantsMenu WHERE MenuName = '" + Label1.Text + "'";


            SqlDataAdapter da = new SqlDataAdapter(command, resturantDB);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataList3.DataSource = ds;
            DataList3.DataBind();


            resturantDB.Close();
        }

        public void fillMenuCategoryDropDownList()
        {

        }
        protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            DropDownList MenuCategory = e.Item.FindControl("DropDownList1") as DropDownList;
            MenuCategory.Items.Insert(0, new ListItem("Swithch Model", "0"));

            SqlConnection resturantDB = new SqlConnection("Server=tcp:resturantsinfo.database.windows.net,1433;Initial Catalog=ResturantsInfo;Persist Security Info=False;User ID=website;Password=335Z!+jUY=anH9f-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            resturantDB.Open();

            SqlCommand cmdFill = new SqlCommand("SELECT DISTINCT Category FROM resturantsMenu ORDER BY Category", resturantDB);
            SqlDataAdapter daFill = new SqlDataAdapter(cmdFill);
            DataSet ds = new DataSet();
            daFill.Fill(ds);
            MenuCategory.DataSource = ds;
            MenuCategory.DataTextField = "Category";
            MenuCategory.DataValueField = "Category";
            MenuCategory.DataBind();
            MenuCategory.Items.Insert(0, new ListItem("Select the Category"));

            resturantDB.Close();
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            calculateDistance();
        }

        public void calculateDistance()
        {
            SqlConnection resturantDB = new SqlConnection("Server=tcp:resturantsinfo.database.windows.net,1433;Initial Catalog=ResturantsInfo;Persist Security Info=False;User ID=website;Password=335Z!+jUY=anH9f-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            resturantDB.Open();
            String command = "SELECT rName, rX, rY FROM resturantsInfo";
            SqlCommand sqlcommand = new SqlCommand(command, resturantDB);
            SqlDataReader reader = sqlcommand.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }
            // Call Close when done reading.
            reader.Close();


            command = "SELECT rName, rX, rY, rDesc, rOpeningHours, rClosingHours, rDaysOpen, rDistance FROM resturantsInfo ORDER BY rDistance";
            SqlDataAdapter da = new SqlDataAdapter(command, resturantDB);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataList4.DataSource = ds;
            DataList4.DataBind();
            DataList1.Visible = false;

            DataList4.Visible = true;

            resturantDB.Close();
        }

        public void ReadSingleRow(IDataRecord record)
        {
            double answer = 0.0;
            double userX = Double.Parse(TextBox1.Text);
            double userY = Double.Parse(TextBox2.Text);
            String resturant = record[0].ToString();
            double resturantX = Double.Parse(record[1].ToString());
            double resturantY = Double.Parse(record[2].ToString());
            double leftside = (resturantX - userX);
            double rightside = (resturantY - userY);
            leftside = leftside * leftside;
            rightside = rightside * rightside;
            answer = leftside + rightside;
            answer = Math.Sqrt(answer);

            SqlConnection resturantDB = new SqlConnection("Server=tcp:resturantsinfo.database.windows.net,1433;Initial Catalog=ResturantsInfo;Persist Security Info=False;User ID=website;Password=335Z!+jUY=anH9f-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            resturantDB.Open();

            String command2 = " WHERE rName = '" + resturant + "' AND rX = '" + resturantX + "' AND rY = '" + resturantY + "'";
            String command3 = "UPDATE resturantsInfo SET rDistance = '" + answer + "'" + command2;

            SqlCommand sqlcommand = new SqlCommand(command3, resturantDB);
            sqlcommand.ExecuteNonQuery();
        }




        public void setDefaultDistance()
        {
            SqlConnection resturantDB = new SqlConnection("Server=tcp:resturantsinfo.database.windows.net,1433;Initial Catalog=ResturantsInfo;Persist Security Info=False;User ID=website;Password=335Z!+jUY=anH9f-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            resturantDB.Open();
            String command = "";
            command = "UPDATE resturantsInfo SET rDistance = 00.00";
            SqlCommand defaultdistance = new SqlCommand(command, resturantDB);
            defaultdistance.ExecuteNonQuery();
            resturantDB.Close();
        }

        protected void DataList4_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Label1.Visible = true;
            DataList4.SelectedIndex = e.Item.ItemIndex;
            Label1.Text = ((Label)DataList4.SelectedItem.FindControl("rNameLabel")).Text;
            fillMenuList();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text.Equals("admin") && TextBox4.Text.Equals("admin"))
                Response.Redirect("adminDashboard.aspx", false);
            else
            {
                Label1.Text = "Not Valid Login";
            }
        }
    }
}