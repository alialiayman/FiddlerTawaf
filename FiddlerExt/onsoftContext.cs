using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace onSoft
{
    public partial class onsoftContext : DbContext
    {
        public string ConnectionString = "Data Source=hajonsoft.com;initial catalog=onsoft;user Id={username};password={password}";
        public onsoftContext()
        {
        }

        public onsoftContext(DbContextOptions<onsoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TawafConfig> TawafConfigs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<TawafConfig>(entity =>
            {
                entity.HasKey(e => e.TawafId);

                entity.Property(e => e.JavalangString)
                    .HasColumnName("javalangString")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.JavautilArrayList)
                    .HasColumnName("javautilArrayList")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RepMofaBoxVer)
                    .IsRequired()
                    .HasColumnName("Rep_Mofa_BoxVer")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RepMofaWrapper)
                    .IsRequired()
                    .HasColumnName("Rep_Mofa_Wrapper")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ThirtyTwoCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VMutGroupsCodeToGetGroups)
                    .IsRequired()
                    .HasColumnName("v_Mut_Groups_CodeToGetGroups")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VMutGroupsWrapper)
                    .IsRequired()
                    .HasColumnName("V_Mut_Groups_Wrapper")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
