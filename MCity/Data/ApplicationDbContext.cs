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
             .HasForeignKey(lp => lp.LearnTopicId)
             .IsRequired(false);

         modelBuilder.Entity<LearnTopic>()
             .HasOne(lt => lt.HomePage)
             .WithOne()
             .HasForeignKey<LearnTopic>(lt => lt.HomePageId)
             .IsRequired(false);
      }
   }
}