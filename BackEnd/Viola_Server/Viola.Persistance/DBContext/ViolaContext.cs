using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Viola.Domain.Entities;
using Viola.Infrastructure.Identity.DBContext;

namespace Viola.Persistance.DBContext
{
    public partial class ViolaContext : ViolaIdentityDbContext
    {

        public ViolaContext(DbContextOptions<ViolaContext> options)
            : base(options)
        {
        }



        public virtual DbSet<Friend> Friends { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-N2G9N3D;Initial Catalog=Viola;User ID=sa;Password=27122003;Encrypt=True;Trust Server Certificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.ToTable("Friend");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Provider).WithMany(p => p.FriendProviders)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friend_User");

                entity.HasOne(d => d.Request).WithMany(p => p.FriendRequests)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Friend_User1");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.FromUid).HasColumnName("FromUId");
                entity.Property(e => e.SendAt).HasColumnType("datetime");

                entity.HasOne(d => d.FromU).WithMany(p => p.MessageFromUs)
                    .HasForeignKey(d => d.FromUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User");

                entity.HasOne(d => d.ToU).WithMany(p => p.MessageToUs)
                    .HasForeignKey(d => d.ToUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.FullName).HasMaxLength(255);
                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);
                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
