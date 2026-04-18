using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
namespace SlctdChecklist.Models 
{
    public class ChecklistDbContext : DbContext
    {
        public ChecklistDbContext(DbContextOptions<ChecklistDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checklist>()
                // .HasMany(c => c.Segments)
                // .WithOne(c => c.Checklist)
                // .HasForeignKey(s => s.ChecklistId)
                // .IsRequired();
                .UseTptMappingStrategy()
                .ToTable("Checklist");
            
            // since ChecklistSubmission inherits from Checklist
            modelBuilder.Entity<ChecklistSubmission>()
                .ToTable("ChecklistSubmissions");

            modelBuilder.Entity<ShiftTask>()
                .UseTptMappingStrategy()
                .ToTable("ShiftTask");

            modelBuilder.Entity<CompletionRecord>()
                .ToTable("CompletionRecords");

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Checklist> Checklists => Set<Checklist>();
        public DbSet<ChecklistSubmission> Submissions => Set<ChecklistSubmission>();
        public DbSet<Segment> Segments => Set<Segment>();
        public DbSet<ShiftTask> Tasks => Set<ShiftTask>();
        public DbSet<CompletionRecord> CompletedTasks => Set<CompletionRecord>();
    }
}