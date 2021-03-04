using LiveScoreSystemWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LiveScoreSystemWebAPI.Controllers
{
    [RoutePrefix("api/Team")]
    public class TeamController : ApiController
    {
        private readonly string ConString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=LiveScore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
//GET
        //getTeamName
        [HttpGet]
        [Route("getTeamName/{teamid}")]
        public string getTeamName(int teamid)
        {
            string name = "";
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.Team", con))
                    {
                        cmd.CommandText = "SELECT name FROM team WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@id", teamid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            name = reader.GetString(0);
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return name;
        }

        //Returns Match title from matchid
        [HttpGet]
        [Route("getMatchTitle/{matchid}")]
        public string getMatchTitle(int matchid)
        {
            string name = "";
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT name FROM match WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@id", matchid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            name = reader.GetString(0);
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return name;
        }

        //Returns toss comment
        [HttpGet]
        [Route("getTossCom/{matchid}")]
        public string getTossCom(int matchid)
        {
            string com = "";
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT tossComment FROM match WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@id", matchid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            com = reader.GetString(0);
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return com;
        }

        //Team Details
        [HttpGet]
        [Route("getTeamDetails/{teamid}")]
        public Team getTeamDetails(int teamid)
        {
            Team t = null;
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT * FROM team WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@id", teamid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            t = new Team
                            {
                                Id = reader.GetInt32(0),
                                Score = reader.GetInt32(1),
                                Wideball = reader.GetInt32(2),
                                Noball = reader.GetInt32(3),
                                Name = reader.GetString(4),
                                Wickets = reader.GetInt32(5),
                                Overs = reader.GetDouble(6),
                                Runrate = reader.GetDouble(7),
                            };
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return t;
        }

        //PalyerDetails
        [HttpGet]
        [Route("getPlayerDetails/{playerid}")]
        public Player getPlayerDetails(int playerid)
        {
            Player p = null;
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT * FROM player WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@id", playerid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            p = new Player
                            {
                                Id = reader.GetInt32(0),
                                Team_id = reader.GetInt32(1),
                                Name = reader.GetString(2),
                                Batruns = reader.GetInt32(3),
                                Wickets = reader.GetInt32(4),
                                Strikerate = reader.GetDouble(5),
                                Economy = reader.GetDouble(6),
                                Balls = reader.GetInt32(7),
                                Fours = reader.GetInt32(8),
                                Sixes = reader.GetInt32(9),
                                Type = reader.GetInt32(10),
                                Overs = reader.GetDouble(11),
                                Bowlruns = reader.GetInt32(12),
                                Status = reader.GetInt32(13)
                            };
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return p;
        }

        //Openers
        [HttpGet]
        [Route("getOpeners/{teamid}")]
        public List<Player> getOpeners(int teamid)
        {
            List<Player> p = new List<Player>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT * FROM player WHERE Team_ID = @id";
                        cmd.Parameters.AddWithValue("@id", teamid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            //For two players only
                            for (int i = 0; i < 2; i++)
                            {
                                reader.Read();
                                Player s = new Player
                                {
                                    Id = reader.GetInt32(0),
                                    Team_id = reader.GetInt32(1),
                                    Name = reader.GetString(2),
                                    Batruns = reader.GetInt32(3),
                                    Wickets = reader.GetInt32(4),
                                    Strikerate = reader.GetDouble(5),
                                    Economy = reader.GetDouble(6),
                                    Balls = reader.GetInt32(7),
                                    Fours = reader.GetInt32(8),
                                    Sixes = reader.GetInt32(9),
                                    Type = reader.GetInt32(10),
                                    Overs = reader.GetDouble(11),
                                    Bowlruns = reader.GetInt32(12),
                                    Status = reader.GetInt32(13)
                                };
                                p.Add(s);
                            }
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return p;
        }

        //New Batsman
        [HttpGet]
        [Route("getNextBatsmans/{teamid}")]
        public List<Player> getNextBatsmans(int teamid)
        {
            List<Player> s = new List<Player>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT * FROM player WHERE Team_ID = @id and status = @sts";
                        cmd.Parameters.AddWithValue("@id", teamid);
                        cmd.Parameters.AddWithValue("@sts", Player.OutStatus.NOTOUT);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Player p = new Player
                                {
                                    Id = reader.GetInt32(0),
                                    Team_id = reader.GetInt32(1),
                                    Name = reader.GetString(2),
                                    Batruns = reader.GetInt32(3),
                                    Wickets = reader.GetInt32(4),
                                    Strikerate = reader.GetDouble(5),
                                    Economy = reader.GetDouble(6),
                                    Balls = reader.GetInt32(7),
                                    Fours = reader.GetInt32(8),
                                    Sixes = reader.GetInt32(9),
                                    Type = reader.GetInt32(10),
                                    Overs = reader.GetDouble(11),
                                    Bowlruns = reader.GetInt32(12),
                                    Status = reader.GetInt32(13)
                                };
                                s.Add(p);
                            }
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return s;
        }

        //Bolwers
        [HttpGet]
        [Route("getBowlers/{teamid}")]
        public List<Player> getBowlers(int teamid)
        {
            List<Player> p = new List<Player>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT * FROM player WHERE (Team_ID = @id) AND (type = @ty1 OR type = @ty2)";
                        cmd.Parameters.AddWithValue("@id", teamid);
                        cmd.Parameters.AddWithValue("@ty1", Player.PlayerType.BOW);
                        cmd.Parameters.AddWithValue("@ty2", Player.PlayerType.AllR);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Player s = new Player
                                {
                                    Id = reader.GetInt32(0),
                                    Team_id = reader.GetInt32(1),
                                    Name = reader.GetString(2),
                                    Batruns = reader.GetInt32(3),
                                    Wickets = reader.GetInt32(4),
                                    Strikerate = reader.GetDouble(5),
                                    Economy = reader.GetDouble(6),
                                    Balls = reader.GetInt32(7),
                                    Fours = reader.GetInt32(8),
                                    Sixes = reader.GetInt32(9),
                                    Type = reader.GetInt32(10),
                                    Overs = reader.GetDouble(11),
                                    Bowlruns = reader.GetInt32(12),
                                    Status = reader.GetInt32(13)
                                };
                                p.Add(s);
                            }
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return p;
        }

        //Commentry
        [HttpGet]
        [Route("getInnComment/{matchid}")]
        public string getInnComment(int matchid)
        {
            string com = "";
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT inningComment FROM match WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@id", matchid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            com = reader.GetString(0);
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Getting Inning Comment-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return com;
        }
        
        //Innning
        [HttpGet]
        [Route("getInning/{matchid}")]
        public int getInning(int matchid)
        {
            int inn = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT inning FROM match WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@id", matchid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            inn = reader.GetInt32(0);
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Getting Innings-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return inn;
        }

        //Matchovers
        [HttpGet]
        [Route("getMatchOvers/{matchid}")]
        public int getMatchOvers(int matchid)
        {
            int overs = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT overs FROM match WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@id", matchid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            overs = reader.GetInt32(0);
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Getting Match Overs-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return overs;
        }

        [HttpGet]
        [Route("getCommentary/{matchid}")]
        public List<Commentary> getCommentary(int matchid)
        {
            List<Commentary> c = new List<Commentary>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT * FROM commentary WHERE Match_ID = @id ORDER BY Id DESC";
                        cmd.Parameters.AddWithValue("@id", matchid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int i = 0, max = 6;
                            while (reader.Read() && i < max)
                            {
                                Commentary com = new Commentary
                                {
                                    Over = reader.GetDouble(2),
                                    Comment = reader.GetString(3),
                                };
                                c.Add(com);
                                i++;
                            }
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Getting Commetaries-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return c;
        }

        [HttpGet]
        [Route("getAllBatsman/{teamid}")]
        public List<Player> getAllBatsman(int teamid)
        {
            List<Player> p = new List<Player>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT * FROM player WHERE Team_ID = @id";
                        cmd.Parameters.AddWithValue("@id", teamid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Player s = new Player
                                {
                                    Id = reader.GetInt32(0),
                                    Team_id = reader.GetInt32(1),
                                    Name = reader.GetString(2),
                                    Batruns = reader.GetInt32(3),
                                    Wickets = reader.GetInt32(4),
                                    Strikerate = reader.GetDouble(5),
                                    Economy = reader.GetDouble(6),
                                    Balls = reader.GetInt32(7),
                                    Fours = reader.GetInt32(8),
                                    Sixes = reader.GetInt32(9),
                                    Type = reader.GetInt32(10),
                                    Overs = reader.GetDouble(11),
                                    Bowlruns = reader.GetInt32(12),
                                    Status = reader.GetInt32(13)
                                };
                                p.Add(s);
                            }
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Getting All Batsman-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return p;
        }

        [HttpGet]
        [Route("getWinnerId/{matchid}")]
        public int getWinnerId(int matchid)
        {
            int win = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT winnerid FROM match WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@id", matchid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            win = reader.GetInt32(0);
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Getting winnerid-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return win;
        }

        [HttpGet]
        [Route("getEndComm/{matchid}")]
        public string getEndComm(int matchid)
        {
            string endc = "";
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "SELECT endComment FROM match WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@id", matchid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            endc = reader.GetString(0);
                            reader.Close();
                        }
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Getting end comment-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return endc;
        }


//Post
        //Inserts a Match
        [HttpPost]
        [Route("insertMatch")]
        public int insertMatch(Match match)
        {
            int matchid = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.Match", con))
                    {
                        cmd.CommandText = "INSERT INTO Match(StartTime, EndTime, Name, overs, endComment, tossComment, team1id, team2id) VALUES(@starttime,@endtime,@name,@overs, @endComment, @tossComment, @team1id, @team2id); SELECT SCOPE_IDENTITY()";
                        cmd.Parameters.AddWithValue("@name", match.Name);
                        cmd.Parameters.AddWithValue("@overs", match.Overs);
                        cmd.Parameters.AddWithValue("@starttime", match.Starttime);
                        cmd.Parameters.AddWithValue("@endtime", match.Endtime);
                        //cmd.Parameters.AddWithValue("@batFirstid", match.Batfirstid);
                        //cmd.Parameters.AddWithValue("@winnerid", match.WinnerId);
                        cmd.Parameters.AddWithValue("@endComment", match.EndComment);
                        cmd.Parameters.AddWithValue("@tossComment", match.TossComment);
                        cmd.Parameters.AddWithValue("@team1id", match.Team1Id);
                        cmd.Parameters.AddWithValue("@team2id", match.Team2Id);

                        matchid = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return matchid;
        }

        //Inserts a player
        [HttpPost]
        [Route("insertPlayer")]
        public void insertPlayer(Player player)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.player", con))
                    {
                        cmd.CommandText = "INSERT INTO player(Team_ID, name, batruns, wickets, strikerate, economy, balls, fours, sixes, type, overs, bowlruns) VALUES(@teamid, @name, @batruns, @wickets, @strikerate, @economy, @balls, @fours, @sixes, @type, @overs, @bowlruns)";
                        cmd.Parameters.AddWithValue("@teamid", player.Team_id);
                        cmd.Parameters.AddWithValue("@name", player.Name);
                        cmd.Parameters.AddWithValue("@batruns", player.Batruns);
                        cmd.Parameters.AddWithValue("@bowlruns", player.Bowlruns);
                        cmd.Parameters.AddWithValue("@wickets", player.Wickets);
                        cmd.Parameters.AddWithValue("@strikerate", player.Strikerate);
                        cmd.Parameters.AddWithValue("@economy", player.Economy);
                        cmd.Parameters.AddWithValue("@balls", player.Balls);
                        cmd.Parameters.AddWithValue("@fours", player.Fours);
                        cmd.Parameters.AddWithValue("@sixes", player.Sixes);
                        cmd.Parameters.AddWithValue("@type", player.Type);
                        cmd.Parameters.AddWithValue("@overs", player.Overs);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

        }


        //Inserts a Team
        [HttpPost]
        [Route("insertTeam")]
        public int insertTeam(Team team)
        {
            int teamid = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.Team", con))
                    {
                        cmd.CommandText = "INSERT INTO team(Score, wideball, Noball, name, wickets, overs) VALUES(@score, @wideball, @noball, @name, @wickets, @overs); SELECT SCOPE_IDENTITY()";

                        cmd.Parameters.AddWithValue("@score", team.Score);
                        cmd.Parameters.AddWithValue("@wideball", team.Wideball);
                        cmd.Parameters.AddWithValue("@noball", team.Noball);
                        cmd.Parameters.AddWithValue("@name", team.Name);
                        cmd.Parameters.AddWithValue("@wickets", team.Wickets);
                        cmd.Parameters.AddWithValue("@overs", team.Overs);

                        teamid = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return teamid;
        }

        //Inserts a commentary
        [HttpPost]
        [Route("insertCommentary")]
        public void insertCommentary(Commentary comment)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                double temp = comment.Over - (int)Math.Floor(comment.Over);
                temp = Math.Round((Double)temp, 1);
                if (temp == 0.6)
                {
                    comment.Over = Math.Ceiling(comment.Over);
                }
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "INSERT INTO Commentary(Match_ID, overs, comment) VALUES(@mid, @over, @comment)";
                        cmd.Parameters.AddWithValue("@mid", comment.Match_ID);
                        cmd.Parameters.AddWithValue("@over", comment.Over);
                        cmd.Parameters.AddWithValue("@comment", comment.Comment);

                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine("\n----------Error in inserting Commentary-----------\n");
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
        }


//DELETE 
        [HttpDelete]
        [Route("deleteComm")]
        public void deleteComm()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "truncate table commentary";
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in deleting Commentaries-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

//PUT

        private const int normball = 0, wide = 1, noball = 2, legbye = 3;
        private const int zero = 0, one = 1, two = 2, three = 3, four = 4, six = 6;
        private const int nowick = 0, strwick = 1, strrunout = 2, nonstrrunout = 3;
        
        private double changeOver(double over)
        {
            return over + 0.1;
        }

        private double changeRunrate(int teamruns, double overs)
        {
            double rr;
            if (overs == 0)
            {
                return 0;
            }
            double temp = Math.Floor(overs);
            double balls = temp * 6 + (overs - temp) * 10;
            rr = teamruns * (6 / balls);
            return rr;
        }

        private double changeStrikeRate(double playerruns, double balls)
        {
            return playerruns * 100 / balls;
        }

        private double changeEconomy(int bowlerruns, double overs)
        {
            double rr;
            if (overs == 0)
            {
                return 0;
            }
            double temp = Math.Floor(overs);
            double balls = temp * 6 + (overs - temp) * 10;
            rr = bowlerruns * (6 / balls);
            return rr;
        }

        //Updating bat first team and toss comment
        [HttpPut]
        [Route("putupdateToss")]
        public void putupdateToss(int matchid, int batfirstid, string tosscom)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "UPDATE match SET batFirstid = @bid, tossComment = @tc WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@id", matchid);
                        cmd.Parameters.AddWithValue("@bid", batfirstid);
                        cmd.Parameters.AddWithValue("@tc", tosscom);
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        [HttpPut]
        [Route("putupdateBall")]
        public double putupdateBall(int batteamid, int bowlteamid, int strikerid, int nonstrikerid, int bowlerid, int runonball, int balltype, int wickettype)
        {
            Team batteam = getTeamDetails(batteamid);
            Team bowlteam = getTeamDetails(bowlteamid);
            Player striker = getPlayerDetails(strikerid);
            Player nonstriker = getPlayerDetails(nonstrikerid);
            Player bowler = getPlayerDetails(bowlerid);
            double over = batteam.Overs;

            //Normal Delivery
            if (balltype == normball)
            {
                string cmd1 = "", cmd2 = "", cmd3 = "", cmd4 = "", cmd5 = "", cmd6 = "", cmd7 = "", cmd8 = "", cmd9 = "", cmd10 = "", cmd11 = "", cmd12 = "", cmd13 = "", cmd14 = "", cmd15 = "", cmd16 = "", cmd17 = "", cmd18 = "";
                over = changeOver(batteam.Overs);
                //Striker run out
                if (wickettype == strrunout)
                {
                    cmd1 = "UPDATE player SET status = " + (int)Player.OutStatus.OUT + " WHERE Id = " + strikerid + ";";
                    int newtwickets = batteam.Wickets + 1;
                    cmd15 = "UPDATE team SET wickets = " + newtwickets + " WHERE Id = " + batteamid + ";";
                }
                //Non striker runout
                else if (wickettype == nonstrrunout)
                {
                    cmd2 = "UPDATE player SET status = " + (int)Player.OutStatus.OUT + " WHERE Id = " + nonstrikerid + ";";
                    int newtwickets = batteam.Wickets + 1;
                    cmd16 = "UPDATE team SET wickets = " + newtwickets + " WHERE Id = " + batteamid + ";";
                }
                //Striker Wicket other than run out
                else if (wickettype == strwick)
                {
                    cmd3 = "UPDATE player SET status = " + (int)Player.OutStatus.OUT + " WHERE Id = " + strikerid + ";";
                    int newtwickets = batteam.Wickets + 1;
                    cmd17 = "UPDATE team SET wickets = " + newtwickets + " WHERE Id = " + batteamid + ";";
                    int newbwickets = bowler.Wickets + 1;
                    cmd18 = "UPDATE player SET wickets = " + newbwickets + "WHERE Id = " + bowlerid + ";";
                }

                //team runs, striker runs, bowler runs
                int newtruns = batteam.Score + runonball;
                int newpruns = striker.Batruns + runonball;
                int newbruns = bowler.Bowlruns + runonball;
                cmd4 = "UPDATE team SET score = " + newtruns + " WHERE Id = " + batteamid + ";";
                cmd5 = "UPDATE player SET batruns = " + newpruns + " WHERE Id = " + strikerid + ";";
                cmd6 = "UPDATE player SET bowlruns = " + newbruns + " WHERE Id = " + bowlerid + ";";

                //teamover, bowler over, striker balls
                double newtover = changeOver(batteam.Overs);
                double newbover = changeOver(bowler.Overs);
                int newsballs = striker.Balls + 1;
                cmd7 = "UPDATE team SET overs = " + Math.Round((Double)newtover, 2) + " WHERE Id = " + batteamid + ";";
                cmd8 = "UPDATE player SET overs = " + Math.Round((Double)newbover, 2) + " WHERE Id = " + bowlerid + ";";
                cmd9 = "UPDATE player SET balls = " + newsballs + " WHERE Id = " + strikerid + ";";


                //striker's strike rate, bowler's economy, team's runrate, 
                double newstkr = changeStrikeRate(newpruns, newsballs);
                double eco = changeEconomy(newbruns, newbover);
                double rr = changeRunrate(newtruns, newtover);
                cmd10 = "UPDATE player SET strikerate = " + Math.Round((Double)newstkr, 2) + " WHERE Id = " + strikerid + ";";
                cmd11 = "UPDATE player SET economy = " + Math.Round((Double)eco, 2) + " WHERE Id = " + bowlerid + ";";
                cmd12 = "UPDATE team SET runrate = " + Math.Round((Double)rr, 2) + " WHERE Id = " + batteamid + ";";

                //player fours, player sixes
                if (runonball == 4)
                {
                    int newfours = striker.Fours + 1;
                    cmd13 = "UPDATE player SET fours = " + newfours + " WHERE Id = " + strikerid + ";";
                }
                if (runonball == 6)
                {
                    int newsixes = striker.Sixes + 1;
                    cmd14 = "UPDATE player SET sixes = " + newsixes + " WHERE Id = " + strikerid + ";";
                }

                //Updating DB
                try
                {
                    using (SqlConnection con = new SqlConnection(ConString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("", con))
                        {
                            cmd.CommandText = cmd1 + cmd2 + cmd3 + cmd4 + cmd5 + cmd6 + cmd7 + cmd8 + cmd9 + cmd10 + cmd11 + cmd12 + cmd13 + cmd14 + cmd15 + cmd16 + cmd17 + cmd18;
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine("\n----------Error in Normall Ball Updation-----------\n");
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            //Wide Ball
            else if (balltype == wide)
            {
                string cmd1 = "", cmd2 = "", cmd3 = "", cmd4 = "", cmd5 = "", cmd6 = "", cmd7 = "", cmd8 = "", cmd9 = "", cmd10 = "", cmd11 = "", cmd12 = "";
                //Striker run out
                if (wickettype == strrunout)
                {
                    cmd1 = "UPDATE player SET status = " + (int)Player.OutStatus.OUT + " WHERE Id = " + strikerid + ";";
                    int newtwickets = batteam.Wickets + 1;
                    cmd2 = "UPDATE team SET wickets = " + newtwickets + " WHERE Id = " + batteamid + ";";
                }
                //Non striker runout
                else if (wickettype == nonstrrunout)
                {
                    cmd3 = "UPDATE player SET status = " + (int)Player.OutStatus.OUT + " WHERE Id = " + nonstrikerid + ";";
                    int newtwickets = batteam.Wickets + 1;
                    cmd4 = "UPDATE team SET wickets = " + newtwickets + " WHERE Id = " + batteamid + ";";
                }
                else if (wickettype == strwick)
                {
                    cmd5 = "UPDATE player SET status = " + (int)Player.OutStatus.OUT + " WHERE Id = " + strikerid + ";";
                    int newtwickets = batteam.Wickets + 1;
                    cmd6 = "UPDATE team SET wickets = " + newtwickets + " WHERE Id = " + batteamid + ";";
                    int newbwickets = bowler.Wickets + 1;
                    cmd7 = "UPDATE player SET wickets = " + newbwickets + " WHERE Id = " + bowlerid + ";";
                }

                //team runs, bowler runs
                int newtruns = batteam.Score + runonball + 1;
                int newbruns = bowler.Bowlruns + runonball + 1;
                cmd8 = "UPDATE team SET score = " + newtruns + " WHERE Id = " + batteamid + ";";
                cmd9 = "UPDATE player SET bowlruns = " + newbruns + " WHERE Id = " + bowlerid + ";";

                //Striker's runs are not counted in his runs.

                //bowler economy, team runrate,
                double eco = changeEconomy(newbruns, bowler.Overs);
                double rr = changeRunrate(newtruns, batteam.Overs);
                cmd10 = "UPDATE player SET economy = " + Math.Round((Double)eco, 2) + " WHERE Id = " + bowlerid + ";";
                cmd11 = "UPDATE team SET runrate = " + Math.Round((Double)rr, 2) + " WHERE Id = " + batteamid + ";";

                //bowling team's wideball
                int newtwide = bowlteam.Wideball + 1;
                cmd12 = "UPDATE team SET wideball = " + newtwide + " WHERE Id = " + bowlteamid + ";";

                //Updating DB
                try
                {
                    using (SqlConnection con = new SqlConnection(ConString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("", con))
                        {
                            cmd.CommandText = cmd1 + cmd2 + cmd3 + cmd4 + cmd5 + cmd6 + cmd7 + cmd8 + cmd9 + cmd10 + cmd11 + cmd12;
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine("\n----------Error  in Wide Ball Updation-----------\n");
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            //Leg Bye ball
            else if (balltype == legbye)
            {
                string cmd1 = "", cmd2 = "", cmd3 = "", cmd4 = "", cmd5 = "", cmd6 = "", cmd7 = "", cmd8 = "", cmd9 = "", cmd10 = "", cmd11 = "";
                over = changeOver(batteam.Overs);
                //Striker run out
                if (wickettype == strrunout)
                {
                    cmd1 = "UPDATE player SET status = " + (int)Player.OutStatus.OUT + " WHERE Id = " + strikerid + ";";
                    int newtwickets = batteam.Wickets + 1;
                    cmd2 = "UPDATE team SET wickets = " + newtwickets + " WHERE Id = " + batteamid + ";";
                }
                //Non striker runout
                else if (wickettype == nonstrrunout)
                {
                    cmd3 = "UPDATE player SET status = " + (int)Player.OutStatus.OUT + " WHERE Id = " + nonstrikerid + ";";
                    int newtwickets = batteam.Wickets + 1;
                    cmd4 = "UPDATE team SET wickets = " + newtwickets + " WHERE Id = " + batteamid + ";";
                }

                //team runs
                int newtruns = batteam.Score + runonball;
                cmd5 = "UPDATE team SET score = " + newtruns + " WHERE Id = " + batteamid + ";";

                //teamover, bowler over, striker balls
                double newtover = changeOver(batteam.Overs);
                double newbover = changeOver(bowler.Overs);
                int newsballs = striker.Balls + 1;
                cmd6 = "UPDATE team SET overs = " + Math.Round((Double)newtover, 2) + " WHERE Id = " + batteamid + ";";
                cmd7 = "UPDATE player SET overs = " + Math.Round((Double)newbover, 2) + " WHERE Id = " + bowlerid + ";";
                cmd8 = "UPDATE player SET balls = " + newsballs + " WHERE Id = " + strikerid + ";";


                //striker's strike rate, bowler's economy, team's runrate, 
                double newstkr = changeStrikeRate(striker.Batruns, newsballs);
                double eco = changeEconomy(bowler.Bowlruns, newbover);
                double rr = changeRunrate(newtruns, newtover);
                cmd9 = "UPDATE player SET strikerate = " + Math.Round((Double)newstkr, 2) + " WHERE Id = " + strikerid + ";";
                cmd10 = "UPDATE player SET economy = " + Math.Round((Double)eco, 2) + " WHERE Id = " + bowlerid + ";";
                cmd11 = "UPDATE team SET runrate = " + Math.Round((Double)rr, 2) + " WHERE Id = " + batteamid + ";";

                //Updating DB
                try
                {
                    using (SqlConnection con = new SqlConnection(ConString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("", con))
                        {
                            cmd.CommandText = cmd1 + cmd2 + cmd3 + cmd4 + cmd5 + cmd6 + cmd7 + cmd8 + cmd9 + cmd10 + cmd11;
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine("\n----------Error in Leg bye Ball Updation-----------\n");
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            //No ball
            else if (balltype == noball)
            {
                string cmd1 = "", cmd2 = "", cmd3 = "", cmd4 = "", cmd5 = "", cmd6 = "", cmd7 = "", cmd8 = "", cmd9 = "";
                //Striker run out
                if (wickettype == strrunout)
                {
                    cmd1 = "UPDATE player SET status = " + (int)Player.OutStatus.OUT + " WHERE Id = " + strikerid + ";";
                    int newtwickets = batteam.Wickets + 1;
                    cmd2 = "UPDATE team SET wickets = " + newtwickets + " WHERE Id = " + batteamid + ";";
                }
                //Non striker runout
                else if (wickettype == nonstrrunout)
                {
                    cmd3 = "UPDATE player SET status = " + (int)Player.OutStatus.OUT + " WHERE Id = " + nonstrikerid + ";";
                    int newtwickets = batteam.Wickets + 1;
                    cmd4 = "UPDATE team SET wickets = " + newtwickets + " WHERE Id = " + batteamid + ";";
                }

                //team runs, bowler runs
                int newtruns = batteam.Score + runonball + 1;
                int newbruns = bowler.Bowlruns + runonball + 1;
                cmd5 = "UPDATE team SET score = " + newtruns + " WHERE Id = " + batteamid + ";";
                cmd6 = "UPDATE player SET bowlruns = " + newbruns + " WHERE Id = " + bowlerid + ";";

                //bowler's economy, team's runrate
                double eco = changeEconomy(newbruns, bowler.Overs);
                double rr = changeRunrate(newtruns, batteam.Overs);
                cmd7 = "UPDATE player SET economy = " + Math.Round((Double)eco, 2) + " WHERE Id = " + bowlerid + ";";
                cmd8 = "UPDATE team SET runrate = " + Math.Round((Double)rr, 2) + " WHERE Id = " + batteamid + ";";

                //bowling team's no ball
                int newtnoball = bowlteam.Noball + 1;
                cmd9 = "UPDATE team SET Noball = " + newtnoball + " WHERE Id = " + bowlteamid + ";";

                //Updating DB
                try
                {
                    using (SqlConnection con = new SqlConnection(ConString))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("", con))
                        {
                            cmd.CommandText = cmd1 + cmd2 + cmd3 + cmd4 + cmd5 + cmd6 + cmd7 + cmd8 + cmd9;
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                catch (SqlException e)
                {
                    System.Diagnostics.Debug.WriteLine("\n----------Error in No Ball Updation-----------\n");
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return over;
        }

        [HttpPut]
        [Route("putupdateTeamOver")]
        public void putupdateTeamOver(double overs, int batteamid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "UPDATE team SET overs = @ov WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@ov", overs);
                        cmd.Parameters.AddWithValue("@id", batteamid);
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Team over updation-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
        
        [HttpPut]
        [Route("putupdateBowlOver")]
        public void putupdateBowlOver(double overs, int bowlerid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "UPDATE player SET overs = @ov WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@ov", overs);
                        cmd.Parameters.AddWithValue("@id", bowlerid);
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Bowler over updation-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        [HttpPut]
        [Route("putupdateInning")]
        public void putupdateInning(int inning, int matchid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "UPDATE match SET inning = @in WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@in", inning);
                        cmd.Parameters.AddWithValue("@id", matchid);
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Innings updation-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        [HttpPut]
        [Route("putupdateInningComm")]
        public void putupdateInningComm(string inncomm, int matchid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "UPDATE match SET inningComment = @in WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@in", inncomm);
                        cmd.Parameters.AddWithValue("@id", matchid);
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Innings Comment updation-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        [HttpPut]
        [Route("putupdateWinner")]
        public void putupdateWinner(int winnerid, int matchid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "UPDATE match SET winnerid = @win WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@win", winnerid);
                        cmd.Parameters.AddWithValue("@id", matchid);
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Updation of winnerid-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        [HttpPut]
        [Route("putupdateEndComm")]
        public void putupdateEndComm(string endcom, int matchid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "UPDATE match SET endComment = @endc WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@endc", endcom);
                        cmd.Parameters.AddWithValue("@id", matchid);
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Updation of endcomment-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        [HttpPut]
        [Route("putupdateEndTime")]
        public void putupdateEndTime(DateTime endtime, int matchid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("", con))
                    {
                        cmd.CommandText = "UPDATE match SET EndTime = @endt WHERE Id = @id";
                        cmd.Parameters.AddWithValue("@endt", endtime);
                        cmd.Parameters.AddWithValue("@id", matchid);
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("\n----------Error in Updation of endtime-----------\n");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }


    }
}