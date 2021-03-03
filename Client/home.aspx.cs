using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
         }

        protected void HostBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("team.aspx");
        }
    }
}