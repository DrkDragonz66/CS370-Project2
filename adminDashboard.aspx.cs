using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _370Resturants
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddResturant.aspx", false);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditMenus.aspx", false);
        }

        private Boolean convertToBoolean(String test)
        {
            if (test.Equals("True"))
                return true;
            else
                return false;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("EditResturant.aspx", false);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainSearch.aspx", false);
        }
    }
}