using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveScoreSystemWebAPI.Models
{
    public class Player
    {
        public enum PlayerType
        {
            BOW,
            BAT,
            AllR
        }
        public enum OutStatus
        {
            NOTOUT,
            OUT
        }
        private int id;
        private string name;
        private int type;
        private int batruns;
        private int bowlruns;
        private int wickets;
        private double strikerate;
        private double economy;
        private double overs;
        private int balls;
        private int fours;
        private int sixes;
        private int team_id;
        private int status;



        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Type { get => type; set => type = value; }

        public int Wickets
        {
            get
            {
                return wickets;
            }
            set
            {
                wickets = value;
            }
        }

        public double Strikerate
        {
            get
            {
                return strikerate;
            }
            set
            {
                strikerate = value;
            }
        }
        
        public double Economy
        {
            get
            {
                return economy;
            }
            set
            {
                economy = value;
            }
        }
        public double Overs { get => overs; set => overs = value; }

        public int Balls
        {
            get
            {
                return balls;
            }
            set
            {
                balls = value;
            }
        }
        public int Fours
        {
            get
            {
                return fours;
            }
            set
            {
                fours = value;
            }
        }
        public int Sixes
        {
            get
            {
                return sixes;
            }
            set
            {
                sixes = value;
            }
        }
        public int Team_id { get => team_id; set => team_id = value; }
        public int Batruns { get => batruns; set => batruns = value; }
        public int Bowlruns { get => bowlruns; set => bowlruns = value; }
        public int Status { get => status; set => status = value; }
        public int Id { get => id; set => id = value; }

    }
}