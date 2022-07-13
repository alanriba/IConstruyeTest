using IConstruye.Dac.Helpers.Interfaces;
using IConstruye.Dac.Model;
using Microsoft.EntityFrameworkCore;

namespace IConstruye.Dac.Providers
{
    public class CatalogosContext : DbContext
    {
        private readonly CatalogosContextSettings contextSettings;
        private readonly IInitialize seedDataService;

        public CatalogosContext(DbContextOptions<CatalogosContext> options, CatalogosContextSettings contextSettings, IInitialize seedDataService)
            : base(options)
        {
            this.contextSettings = contextSettings;
            this.seedDataService = seedDataService;
        }

        public DbSet<ProductModel> ProductModel { get; set; }
        public DbSet<ClientModel> ClientModel { get; set; }
        public DbSet<SaleModel> SaleModel { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(contextSettings.DefaultSchema);

            seedDataService.Initialize(modelBuilder);

            DeshabilitarBorradoEnCascada(modelBuilder);
        }

        private void DeshabilitarBorradoEnCascada(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
