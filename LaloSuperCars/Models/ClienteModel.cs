using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaloSuperCars.Models
{
    [Table("cliente")]
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id_cliente")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("fecha_nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Column("sexo")]
        public string Sexo { get; set; }

        [Column("usuario")]
        public string Usuario { get; set; }

        [Column("contraseña")]
        public int Contraseña { get; set; }
    }
}
