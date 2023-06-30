using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaloSuperCars.Models
{
    [Table("direccion")]
    public class DireccionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id_direccion")]
        public int Id { get; set; }

        [Column("pais")]
        public string Pais { get; set; }

        [Column("ciudad")]
        public String Ciudad { get; set; }

        [Column("calle")]
        public string Calle { get; set; }
        
        [Column("numero")]
        public string Numero { get; set; }

        [Column("id_cliente")]
        public int IdCliente { get; set; }
    }
}
