using System.ComponentModel.DataAnnotations;

namespace LavanderiaApp.Models
{
    public class Cliente
    {

        [Key]
        public int Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string telefono1 { get; set; }
        public string telefono2 { get; set; }



        [EmailAddress]
        public string email { get; set; }
        public string direccion { get; set; }

    }
}
