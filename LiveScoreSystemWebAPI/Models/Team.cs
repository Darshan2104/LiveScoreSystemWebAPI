using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveScoreSystemWebAPI.Models
{
    public class Team
    {
        private int id;
        private string name;
        private int score;
        private int wideball;
        private int noball;
        private int wickets;
        private double overs;
        private double runrate;
        
        public int Noball { get => noball; set => noball = value; }
        
        public int Wideball { get => wideball; set => wideball = value; }
       
        public int Score { get => score; set => score = value; }

        public string Name { get => name; set => name = value; }
        
        public int Wickets { get => wickets; set => wickets = value; }
        
        public double Overs { get => overs; set => overs = value; }
        
        public double Runrate { get => runrate; set => runrate = value; }
       
        public int Id { get => id; set => id = value; }
    }
}