using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveScoreSystemWebAPI.Models
{
    public class Match
    {
        private int id;
        private string name;
        private int team1id;
        private int team2id;
        private int overs;
        private int batfirstid;
        private int winnerid;
        private string endComment;
        private string tossComment;
        private DateTime starttime;
        private DateTime endtime;
        private int inning;
        private string inningComment;
        public string Name { get => name; set => name = value; }
        public int Team1Id { get => team1id; set => team1id = value; }
        public int Team2Id { get => team2id; set => team2id = value; }
        public DateTime Starttime { get => starttime; set => starttime = value; }
        public DateTime Endtime { get => endtime; set => endtime = value; }
        public int Overs { get => overs; set => overs = value; }
        public int Batfirstid { get => batfirstid; set => batfirstid = value; }
        public int WinnerId { get => winnerid; set => winnerid = value; }
        public string EndComment { get => endComment; set => endComment = value; }
        public string TossComment { get => tossComment; set => tossComment = value; }
        public int Id { get => id; set => id = value; }
        public int Inning { get => inning; set => inning = value; }
        public string InningComment { get => inningComment; set => inningComment = value; }
    }
}