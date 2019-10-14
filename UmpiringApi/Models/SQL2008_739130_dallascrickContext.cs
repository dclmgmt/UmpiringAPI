using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UmpiringApi.Models
{
    public partial class SQL2008_739130_dallascrickContext : DbContext
    {
        public SQL2008_739130_dallascrickContext()
        {
        }

        public SQL2008_739130_dallascrickContext(DbContextOptions<SQL2008_739130_dallascrickContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MatchStats> MatchStats { get; set; }
        public virtual DbSet<Migration> Migration { get; set; }
        public virtual DbSet<MigrationRelation> MigrationRelation { get; set; }
        public virtual DbSet<TblBook> TblBook { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<UnlockScoresheet> UnlockScoresheet { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }

        [NotMapped]
        public virtual DbSet<Assignment> Assignments { get; set; }
        // Unable to generate entity type for table 'dbo.address'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.award_types'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.dtproperties'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ground'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.match'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.match_batting'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.match_bowling'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PaymentDetails'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.penalty'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.phone'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.player'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.player_batting'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.player_bowling'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.role'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.rules'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.team'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.team_registration'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tournament'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tournament_awards'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tournament_team'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.user_role'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.users'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.announcement'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.log'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.team_division'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ground_reservations'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.bis_dcl'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tempDups2'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.match1'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.FloodLight2016'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.floodlight'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.email'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Tournament_Contact'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Schedule_Teams'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Schedule_Common_Teams'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Schedule_Games'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.test_cash'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=sql2k802.discountasp.net;Database=SQL2008_739130_dallascrick;Trusted_Connection=True;User Id=SQL2008_739130_dallascrick_user;Password=dcl650;Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<MatchStats>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.TeamId })
                    .HasName("PK__match_st__42FD15784A8310C6");

                entity.ToTable("match_stats");

                entity.Property(e => e.MatchId).HasColumnName("match_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.Byes).HasColumnName("byes");

                entity.Property(e => e.Extras).HasColumnName("extras");

                entity.Property(e => e.InningSw).HasColumnName("inning_sw");

                entity.Property(e => e.LegByes).HasColumnName("leg_byes");

                entity.Property(e => e.Nos).HasColumnName("nos");

                entity.Property(e => e.OverThrow).HasColumnName("over_throw");

                entity.Property(e => e.Overs).HasColumnName("overs");

                entity.Property(e => e.RunsScored).HasColumnName("runs_scored");

                entity.Property(e => e.TotalRuns).HasColumnName("total_runs");

                entity.Property(e => e.Wickets).HasColumnName("wickets");

                entity.Property(e => e.Wides).HasColumnName("wides");
            });

            modelBuilder.Entity<Migration>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.SqlId, e.SecondaryKey })
                    .HasName("PK_key_sqlId_secondaryKey");

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MongoId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MigrationRelation>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.SqlId, e.SecondaryKey })
                    .HasName("PK1_key_sqlid_secondarykey");

                entity.ToTable("Migration_Relation");

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBook>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Author)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<TblRole>()
                .Property(e => e.RoleName)
                .IsUnicode(false);
            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(128);

                entity.Property(e => e.Salt).HasMaxLength(128);
            });

            modelBuilder.Entity<UnlockScoresheet>(entity =>
            {
                entity.ToTable("unlock_scoresheet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GroupName)
                    .HasColumnName("group_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MatchId).HasColumnName("match_id");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamRequesting)
                    .HasColumnName("team_requesting")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });
        }
    }
}
