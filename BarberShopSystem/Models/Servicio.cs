namespace BarberShopSystem.Models
{
    public class Servicio
    {
        public Servicio()
        {
            // Se inicializa la lista ProfesionalServicios con una lista vacía
            ProfesionalServicios = new List<ProfesionalServicio>();
        }
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int Duracion { get; set; }
        public decimal Precio { get; set; }

        // Relaciones con otras tablas
        public List<ProfesionalServicio> ProfesionalServicios { get; set; }
    }
}
