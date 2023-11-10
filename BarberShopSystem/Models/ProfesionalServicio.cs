namespace BarberShopSystem.Models
{
    public class ProfesionalServicio
    {
        // Clave primaria compuesta
        public int ProfesionalId { get; set; }
        public int ServicioId { get; set; }

        // Relaciones con otras tablas
        public Profesional? Profesional { get; set; }
        public Servicio? Servicio { get; set; }
    }
}
