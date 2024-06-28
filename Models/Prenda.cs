using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LavanderiaApp.Models
{
    public class Prenda
    {
        [Key]
        public int IdPrenda { get; set; }

        [Required]
        public int CedulaPropietario { get; set; }

        
        public int TipoPrendaId { get; set; }
        [ForeignKey("TipoPrendaId")]
        public TipoPrenda TipoPrenda { get; set; }

       
        public int TipoTelaId { get; set; }
        [ForeignKey("TipoTelaId")]
        public TipoTela TipoTela { get; set; }

        public string EspecificacionesLavado { get; set; }

   
        [ForeignKey("CedulaPropietario")]
        public Cliente Propietario { get; set; }
    }

    public class TipoPrenda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }

    public class TipoTela
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
