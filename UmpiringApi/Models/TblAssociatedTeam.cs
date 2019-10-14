using System.Collections.Generic;

namespace UmpiringApi.Models
{
    public partial class TblAssociatedTeam
    {
        public TblAssociatedTeam()
        {
            TblUmpiringRequest = new HashSet<TblUmpiringRequest>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string TeamName { get; set; }

        public virtual TblUser User { get; set; }
        public virtual ICollection<TblUmpiringRequest> TblUmpiringRequest { get; set; }
    }
}
