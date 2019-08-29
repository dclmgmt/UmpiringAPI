using System;
using System.Collections.Generic;

namespace UmpiringApi.Models
{
    public partial class UnlockScoresheet
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string TeamRequesting { get; set; }
        public string GroupName { get; set; }
    }
}
