using Microsoft.EntityFrameworkCore;
using MyGolfHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyGolfHelper.Data
{
    public class MyGolfHelperDbContext : DbContext
    {
        public MyGolfHelperDbContext(DbContextOptions<MyGolfHelperDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<GolfClub> GolfClubs { get; set; }
        public DbSet<GolfCourse> GolfCourses { get; set; }
        public DbSet<GolfCourseRating> GolfCourseRatings { get; set; }
        public DbSet<GolfHole> GolfHoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.UseIdentityColumns(1, 1);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Username).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(75);
                entity.Property(e => e.CreatedAt).IsRequired();

                entity.HasOne(e => e.Information)
                    .WithOne(e => e.User)
                    .HasForeignKey<UserInformation>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                entity.HasOne(e => e.PlayerStatistics)
                    .WithOne(e => e.User)
                    .HasForeignKey<PlayerStatistic>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                entity.HasIndex(e => e.Username).IsUnique();
            });

            modelBuilder.Entity<UserInformation>(entity => {

                entity.ToTable("UserInformation");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();

                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.PhoneNumber).IsUnique();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasConversion(
                        r => r.ToString(),
                        r => (RoleType)Enum.Parse(typeof(RoleType), r));
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.HasKey(e => new { e.RoleId, e.UserId });
                
                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserRoles);
                entity.HasOne(e => e.Role)
                    .WithMany(r => r.UserRoles);
            });

            modelBuilder.Entity<GolfClub>(entity =>
            {
                entity.ToTable("GolfClub");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(70);
                entity.Property(e => e.CreatedAt).IsRequired();

                entity.HasMany(e => e.Courses)
                    .WithOne(e => e.Club)
                    .HasForeignKey(e => e.ClubId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<GolfCourse>(entity =>
            {
                entity.ToTable("GolfCourse");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(70);

                entity.HasOne(e => e.Ratings)
                    .WithOne(e => e.GolfCourse)
                    .HasForeignKey<GolfCourseRating>(e => e.GolfCourseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                entity.HasMany(e => e.Holes)
                    .WithOne(e => e.Course)
                    .HasForeignKey(e => e.CourseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<GolfCourseRating>(entity =>
            {
                entity.ToTable("GolfCourseRating");

                entity.HasKey(e => e.GolfCourseId);

            });

            modelBuilder.Entity<Hazard>(entity => 
            {
                entity.ToTable("Hazard");

                entity.HasMany(e => e.GolfHoleHazards)
                    .WithOne(e => e.Hazard)
                    .HasForeignKey(e => e.HazardId);
            });

            modelBuilder.Entity<GolfHole>(entity =>
            {
                entity.ToTable("GolfHole");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Par).IsRequired();

                entity.HasMany(e => e.GolfHoleHazards)
                    .WithOne(e => e.GolfHole)
                    .HasForeignKey(e => e.GolfHoleId);
            });

            modelBuilder.Entity<GolfHoleHazard>(entity =>
            {
                entity.ToTable("GolfHoleHazard");

                entity.HasKey(e => new { e.GolfHoleId, e.HazardId });

                entity.HasOne(e => e.GolfHole)
                    .WithMany(e => e.GolfHoleHazards);
                entity.HasOne(e => e.Hazard)
                    .WithMany(e => e.GolfHoleHazards);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.ToTable("PlayerStatistic");

                entity.HasKey(e => e.UserId);
            });
        }

        public override int SaveChanges()
        {
            AddTimeStamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimeStamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimeStamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && 
                (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.Now;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                    continue;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
