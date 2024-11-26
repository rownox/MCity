using MCity.Components.Shared;
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
      public DbSet<TreeModel> TreeModels { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
         base.OnModelCreating(modelBuilder);

         //Learn Page
         modelBuilder.Entity<LearnPage>()
            .HasOne(lp => lp.LearnTopic)
            .WithMany(lt => lt.Pages)
            .HasForeignKey(lp => lp.LearnTopicId);

         //Learn Topic
         modelBuilder.Entity<LearnTopic>()
            .HasMany(lt => lt.Pages)
            .WithOne(lp => lp.LearnTopic)
            .HasForeignKey(lp => lp.LearnTopicId)
            .IsRequired(false);

         modelBuilder.Entity<LearnTopic>()
            .HasMany(lt => lt.SubTopics)
            .WithOne(st => st.ParentTopic)
            .HasForeignKey(st => st.ParentTopicId)
            .IsRequired(false);

         //Tree Model
         modelBuilder.Entity<TreeModel>()
            .HasMany(tm => tm.Children)
            .WithOne(c => c.Parent)
            .HasForeignKey(c => c.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
      }
   }
}