namespace BarberShopSystem.Models
{
    public class Cupo
    {

        public int Id { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public bool EstadoCupo { get; set; }
        public int ServiciosDisponibles { get; set; }

        // Relaciones con otras tablas
        public int ProfesionalId { get; set; }
        public Profesional? Profesional { get; set; }
    }
}
