using Microsoft.EntityFrameworkCore;
using PatientPortal.Entity;

namespace PatientPortal.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<PatientsInformation> PatientsInformation { get; set; }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<NCD> NCDs { get; set; }

        public MyDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) 
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiseaseInformation>().HasOne(d => d.PatientsInformation).WithMany(p => p.Diseases).HasForeignKey(d => d.PatientId);
              
        }
    }
}
