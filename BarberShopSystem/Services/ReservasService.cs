using BarberShopSystem.Models;

namespace BarberShopSystem.Services
{
    // (Inyección de dependencias: SOLID) Este servicio se encarga de obtener la lista de reservas desde la base de datos o cualquier otra fuente de datos.
    public class ReservasService
    {
        // Método para obtener la lista de reservas
        public List<Reserva> ObtenerListaDeReservas()
        {
            // Simulación de obtención de datos (actualmente no se extrae info de la BD)
            List<Reserva> reservas = new List<Reserva>
            {
                new Reserva { Id = 1, Fecha = DateTime.Now, ProfesionalId = 1 },
                new Reserva { Id = 2, Fecha = DateTime.Now.AddDays(1), ProfesionalId = 2 },
            };

            return reservas;
        }
    }
}
