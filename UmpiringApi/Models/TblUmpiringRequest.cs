namespace UmpiringApi.Models
{
    public partial class TblUmpiringRequest
    {
        public int Id { get; set; }
        public int? TournamentId { get; set; }
        public int? TeamId { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }

        public virtual TblUmpiringStatus Status { get; set; }
        public virtual TblAssociatedTeam Team { get; set; }
        public virtual TblUser User { get; set; }
    }
}
