using System;

namespace BarberShopSystem.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ProfesionalId { get; set; }
        // Otros campos relevantes
    }
}
