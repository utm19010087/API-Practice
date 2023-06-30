using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace LaloSuperCars.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }

        public DbSet<ProveedorModel> proveedorModel{ get; set; }

        public DbSet<ConcesionarioModel> concesionarioModel { get; set;}

        public DbSet<CategoriaCocheModel> categoriaCocheModel { get; set; }
        public DbSet<CocheModel> cocheModel { get; set; }
        public DbSet<RevisionesModel> revisionesModel { get; set; }
        public DbSet<Detalle_RevisionModel> detalle_RevisionModel { get; set; }
        public DbSet<EmpleadoModel> empleadoModel { get; set; }
        public DbSet<ClienteModel> clienteModel { get; set; }
        public DbSet<ContactoModel> contactoModel { get; set; }
        public DbSet<DireccionModel> direccionModel { get; set; }
        public DbSet<VentaModel> ventaModel { get; set; }
    }

}
