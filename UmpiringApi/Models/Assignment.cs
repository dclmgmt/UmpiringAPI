using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmpiringApi.Models
{
    public class Assignment
    {
        public DateTime MatchDate { get; set; }
        public string MatchName { get; set; }
        public string GroundName { get; set; }
        public string GroundAddress { get; set; }
        public string GroupName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
    }
}
