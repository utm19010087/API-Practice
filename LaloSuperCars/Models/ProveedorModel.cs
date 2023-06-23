using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace LaloSuperCars.Models
{
    [Table("proveedor")]
    public class ProveedorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        [Column("id_proveedor")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }
    }
}
