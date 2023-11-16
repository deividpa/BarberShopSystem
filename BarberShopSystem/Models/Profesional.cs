using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShopSystem.Models
{
    public class Profesional
    {
        public Profesional()
        {
            // Inicializa la lista en el constructor para evitar la advertencia CS8618
            ServiciosSeleccionados = new List<int>();
        }
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? NumeroTelefono { get; set; }

        // Relación con otras tablas
        public List<Reserva>? Reservas { get; set; }
        public List<Cupo>? Cupos { get; set; }
        public List<ProfesionalServicio>? ProfesionalServicios { get; set; }

        [Display(Name = "Servicios")]
        [NotMapped] // Esta propiedad no se mapeará a la base de datos
        public List<int> ServiciosSeleccionados { get; set; }
    }
}
