using System.ComponentModel.DataAnnotations;

namespace LavanderiaApp.Models
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string prendaId { get; set; }
        public Prenda Prenda { get; set; }

        [Required]
        public string cedulaPropietario { get;  set; }
        public DateTime fechaRecibo { get; set; }

        public string comentarios { get; set; }

        public int estadoServicioId { get; set; }
        public EstadoServicio EstadoServicio { get; set; }

        public DateTime fechaDevolucion {  get; set; }

    }

    public class EstadoServicio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int estado { get; set; }

    }   
}
