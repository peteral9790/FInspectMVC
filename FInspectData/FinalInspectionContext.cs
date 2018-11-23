namespace FInspectData
{
    using FInspectData.Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class FinalInspectionContext : DbContext
    {
        public FinalInspectionContext()
            : base("name=FinalInspectionContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Entity<FinalInspection>().HasMany(x => x.FinalInspectionUploads).WithRequired(x => x.FinalInspection).WillCascadeOnDelete();
        }
        public virtual DbSet<FinalInspection> FinalInspections { get; set; }
        public virtual DbSet<Inspector> Inspectors { get; set; }
        public virtual DbSet<Nonconformance> Nonconformances { get; set; }
        public virtual DbSet<Assembly> Assemblies { get; set; }
        public virtual DbSet<MiStatusTransaction> MiStatusTransactions { get; set; }
        public virtual DbSet<FinalInspectionUpload> FinalInspectionUploads { get; set; }
    }
}