using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaloSuperCars.Models
{
    [Table("revisiones")]
    public class RevisionesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id_revisiones")]
        public int Id { get; set; }

        [Column("id_coche")]
        public int IdCoche { get; set; }

        [Column("fecha")]
        public string Fecha { get; set; }
    }
}
