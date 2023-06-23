using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaloSuperCars.Models
{
    [Table("coche")]
    public class CocheModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id_coche")]
        public int Id { get; set; }

        [Column("id_concesionario")]
        public int IdConcesionario { get; set; }

        [Column("matricula")]
        public string Matricula { get; set; }

        [Column("marca")]
        public string Marca { get; set; }

        [Column("modelo")]
        public string Modelo { get; set; }

        [Column("color")]
        public string Color { get; set; }

        [Column("precio")]
        public double Precio { get; set; }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }
    }
}
