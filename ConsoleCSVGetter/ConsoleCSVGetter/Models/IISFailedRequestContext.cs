using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleCSVGetter.Models
{
    public partial class IISFailedRequestContext : DbContext
    {
        public IISFailedRequestContext()
        {
        }

        public IISFailedRequestContext(DbContextOptions<IISFailedRequestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TNew> TNew { get; set; }

        // Unable to generate entity type for table 'log.t_fal_req_log_dtl'. Please see the warning messages.
        // Unable to generate entity type for table 'log.t_htp_cde'. Please see the warning messages.
        // Unable to generate entity type for table 'log.t_fal_req_log'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=EDYN-REP-DB-01.CORP.EDYNAMIX.CO.UK\\INTERN;Database=IISFailedRequest;User Id=Uchenici;Password=edynamix12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:DefaultSchema", "log");

            modelBuilder.Entity<TNew>(entity =>
            {
                entity.ToTable("t_NEW");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActivityId)
                    .IsRequired()
                    .HasColumnName("activityId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppPoolId)
                    .HasColumnName("appPoolId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AuthenticationType)
                    .HasColumnName("authenticationType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.FailureReason)
                    .HasColumnName("failureReason")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessId).HasColumnName("processId");

                entity.Property(e => e.ReasonDescription)
                    .HasColumnName("reasonDescription")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.RemoteUserName)
                    .HasColumnName("remoteUserName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ServerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SiteId).HasColumnName("siteId");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StatusCode)
                    .HasColumnName("statusCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TimeTaken).HasColumnName("timeTaken");

                entity.Property(e => e.TokenUserName)
                    .HasColumnName("tokenUserName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TriggerStatusCode)
                    .HasColumnName("triggerStatusCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Verb)
                    .HasColumnName("verb")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.XmlDta)
                    .HasColumnName("xml_dta")
                    .HasColumnType("xml");
            });
        }
    }
}
