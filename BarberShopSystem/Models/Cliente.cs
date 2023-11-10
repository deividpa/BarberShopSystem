namespace BarberShopSystem.Models
{
    public class Cliente
    {
        public Cliente()
        {
            // Se inicializa la lista Reservas con una lista vacía
            Reservas = new List<Reserva>();
        }
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? NumeroTelefono { get; set; }

        // Relación con otras tablas
        public List<Reserva> Reservas { get; set; }
    }
}
