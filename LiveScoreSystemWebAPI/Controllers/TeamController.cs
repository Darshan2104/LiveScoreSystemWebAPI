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
    }
}