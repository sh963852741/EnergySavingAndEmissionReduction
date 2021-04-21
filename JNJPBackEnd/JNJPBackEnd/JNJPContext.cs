using JNJPBackEnd.Modules;
using Microsoft.EntityFrameworkCore;

namespace JNJPBackEnd
{
    public class JNJPContext : DbContext
    {
        public JNJPContext(DbContextOptions<JNJPContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<RecycleForm> RecycleForms { get; set; }
        public DbSet<CreditDetail> CreditDetails { get; set; }
        public DbSet<Maquillage> Maquillages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategories)
                .WithOne()
                .HasForeignKey(d => d.ParentID)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
