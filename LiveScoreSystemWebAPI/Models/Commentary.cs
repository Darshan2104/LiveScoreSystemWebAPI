using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveScoreSystemWebAPI.Models
{
    public class Commentary
    {
        private int id;
        private int match_id;
        private double over;
        private string comment;
        private DateTime time;
        public int Match_ID { get => match_id; set => match_id = value; }
        public DateTime Time { get => time; set => time = value; }
        public string Comment { get => comment; set => comment = value; }
        public double Over { get => over; set => over = value; }
        public int Id { get => id; set => id = value; }
    }

}