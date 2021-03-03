using LiveScoreSystemWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class team : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name;
            foreach (int i in Enum.GetValues(typeof(Player.PlayerType)))
            {
                name = Enum.GetName(typeof(Player.PlayerType), i);
                ddlt1p1type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p1type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p2type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p2type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p3type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p3type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p4type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p4type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p5type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p5type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p6type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p6type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p7type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p7type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p8type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p8type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p9type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p9type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p10type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p10type.Items.Add(new ListItem(name, i.ToString()));
                ddlt1p11type.Items.Add(new ListItem(name, i.ToString()));
                ddlt2p11type.Items.Add(new ListItem(name, i.ToString()));
            }
        }



    }
}