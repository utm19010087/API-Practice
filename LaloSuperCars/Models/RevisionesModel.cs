using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaloSuperCars.Models
{
    [Table("revision")]
    public class RevisionesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id_revision")]
        public int Id { get; set; }

        [Column("id_coche")]
        public int IdCoche { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }
    }
}
