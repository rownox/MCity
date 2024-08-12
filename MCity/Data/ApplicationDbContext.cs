using MCity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MCity.Data {
   public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options) {
      }

      public DbSet<LearnPage> LearnPages { get; set; }
      public DbSet<LearnTopic> LearnTopics { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
         base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<LearnPage>()
             .HasOne(lp => lp.LearnTopic)
             .WithMany(lt => lt.Pages)
             .HasForeignKey(lp => lp.LearnTopicId);

         modelBuilder.Entity<LearnTopic>()
             .HasMany(lt => lt.Pages)
             .WithOne(lp => lp.LearnTopic)
             .HasForeignKey(lp => lp.LearnTopicId)
             .IsRequired(false);
      }
   }
}