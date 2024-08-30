using Microsoft.EntityFrameworkCore;

namespace MidExam31_8_24.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> optopns) : base(optopns)
        { }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
                entity.Property(e => e.ImageName).IsUnicode(false);
                entity.Property(e => e.ImageUrl).IsUnicode(false);
                entity.Property(e => e.JoinDate).HasColumnType("date");
                entity.Property(e => e.EmployeeName).HasMaxLength(50).IsUnicode(false);

            });
            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experience");
                entity.Property(e => e.Title).HasMaxLength(50).IsUnicode(false);
                entity.HasOne(d => d.Employee).WithMany(p => p.Experiences).HasForeignKey(d => d.EmployeeId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Experience_Employee");
            });
        }
    }
}
