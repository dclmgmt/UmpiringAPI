using System.Collections.Generic;

namespace UmpiringApi.Models
{
    public partial class TblUmpiringStatus
    {
        public TblUmpiringStatus()
        {
            TblUmpiringRequest = new HashSet<TblUmpiringRequest>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<TblUmpiringRequest> TblUmpiringRequest { get; set; }
    }
}
