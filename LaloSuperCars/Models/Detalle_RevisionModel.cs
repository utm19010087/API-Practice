using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaloSuperCars.Models
{
    [Table("Detalle_Revision")]
    public class Detalle_RevisionModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id_detalle_revision")]
        public int Id_detalle_revision { get; set; }

        [Column("id_revisiones")]
        public int IdRevisiones { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("costo")]
        public double Costo { get; set; }
    }
}
