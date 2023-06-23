using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaloSuperCars.Models
{
    [Table("concesionario")]
    public class ConcesionarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id_concesionario")]
        public int Id { get; set; }

        [Column("id_proveedor")]
        public string IdProveedor { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }
    }
}
