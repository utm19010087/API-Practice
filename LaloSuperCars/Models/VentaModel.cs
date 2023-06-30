using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaloSuperCars.Models
{
    [Table("venta")]
    public class VentaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id_venta")]
        public int Id { get; set; }

        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [Column("id_empleado")]
        public int IdEmpleado { get; set; }

        [Column("id_coche")]
        public int IdCoche { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }
    }
}
