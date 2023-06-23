using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaloSuperCars.Models
{
    [Table("categoriacoche")]
    public class CategoriaCocheModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id_categoria")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

    }
}
