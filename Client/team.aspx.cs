using LiveScoreSystemWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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


        protected void GoBtn_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44382/api/Team");
            

            //Adding teams
            Team team1 = new Team
            {
                Name = tbteam1.Text,
                Score = 0,
                Wideball = 0,
                Noball = 0,
                Wickets = 0,
                Overs = 0,
            };
            Team team2 = new Team
            {
                Name = tbteam2.Text,
                Score = 0,
                Wideball = 0,
                Noball = 0,
                Wickets = 0,
                Overs = 0,
            };



            int team1_id = client.PostAsync<Team>("insertTeam",team1);
            int team2_id = client.PostAsync<Team>("insertTeam", team2);
            //int team1_id = client.insertTeam(team1);
            //int team2_id = client.insertTeam(team2);
            Session["team1id"] = team1_id;
            Session["team2id"] = team2_id;

            //Adding matches
            //Ending time is after 1 year temporarily
            //Bat first team and toss comment is selected in toss.aspx
            DateTime dt = DateTime.Now;

            //DateTime is immutable
            dt = dt.AddYears(1);
            Match match = new Match
            {
                Name = tbmatchtitle.Text,
                Starttime = DateTime.Now,
                Endtime = dt,
                Overs = Int32.Parse(ddlovers.SelectedValue),
                Batfirstid = -1,
                WinnerId = -1,
                EndComment ="",
                TossComment = "",
                Team1Id = team1_id,
                Team2Id = team2_id
            };
            int match_id = client.insertMatch(match);
            Session["matchid"] = match_id;

            


            Player player11 = new Player { Name = t1p1.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p1type.SelectedValue) };
            Player player12 = new Player { Name = t1p2.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p2type.SelectedValue) };
            Player player13 = new Player { Name = t1p3.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p3type.SelectedValue) };
            Player player14 = new Player { Name = t1p4.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p4type.SelectedValue) };
            Player player15 = new Player { Name = t1p5.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p5type.SelectedValue) };
            Player player16 = new Player { Name = t1p6.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p6type.SelectedValue) };
            Player player17 = new Player { Name = t1p7.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p7type.SelectedValue) };
            Player player18 = new Player { Name = t1p8.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p8type.SelectedValue) };
            Player player19 = new Player { Name = t1p9.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p9type.SelectedValue) };
            Player player110 = new Player { Name = t1p10.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p10type.SelectedValue) };
            Player player111 = new Player { Name = t1p11.Text, Team_id = team1_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt1p11type.SelectedValue) };


            Player player21 = new Player { Name = t2p1.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p1type.SelectedValue) };
            Player player22 = new Player { Name = t2p2.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p2type.SelectedValue) };
            Player player23 = new Player { Name = t2p3.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p3type.SelectedValue) };
            Player player24 = new Player { Name = t2p4.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p4type.SelectedValue) };
            Player player25 = new Player { Name = t2p5.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p5type.SelectedValue) };
            Player player26 = new Player { Name = t2p6.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p6type.SelectedValue) };
            Player player27 = new Player { Name = t2p7.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p7type.SelectedValue) };
            Player player28 = new Player { Name = t2p8.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p8type.SelectedValue) };
            Player player29 = new Player { Name = t2p9.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p9type.SelectedValue) };
            Player player210 = new Player { Name = t2p10.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p10type.SelectedValue) };
            Player player211 = new Player { Name = t2p11.Text, Team_id = team2_id, Wickets = 0, Strikerate = 0, Economy = 0, Overs = 0, Balls = 0, Fours = 0, Sixes = 0, Type = Int32.Parse(ddlt2p11type.SelectedValue) };
            client.insertPlayer(player11);
            client.insertPlayer(player12);
            client.insertPlayer(player13);
            client.insertPlayer(player14);
            client.insertPlayer(player15);
            client.insertPlayer(player16);
            client.insertPlayer(player17);
            client.insertPlayer(player18);
            client.insertPlayer(player19);
            client.insertPlayer(player110);
            client.insertPlayer(player111);

            client.insertPlayer(player21);
            client.insertPlayer(player22);
            client.insertPlayer(player23);
            client.insertPlayer(player24);
            client.insertPlayer(player25);
            client.insertPlayer(player26);
            client.insertPlayer(player27);
            client.insertPlayer(player28);
            client.insertPlayer(player29);
            client.insertPlayer(player210);
            client.insertPlayer(player211); 

            Response.Redirect("toss.aspx");
        }
    }
}