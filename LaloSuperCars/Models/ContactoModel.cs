using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaloSuperCars.Models
{
    [Table("contacto")]
    public class ContactoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id_contacto")]
        public int Id { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("mail")]
        public string Mail { get; set; }

        [Column("id_cliente")]
        public int IdContacto { get; set; }
    }
}
