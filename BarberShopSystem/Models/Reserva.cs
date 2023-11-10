using System;

namespace BarberShopSystem.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        // Relaciones con otras tablas
        public int ProfesionalId { get; set; }
        public Profesional? Profesional { get; set; }
        public int CupoId { get; set; }
        public Cupo? Cupo { get; set; }
        public int ServicioId { get; set; }
        public Servicio? Servicio { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // Otros campos
        public bool EstadoReserva { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime HoraCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string? Novedad { get; set; }
    }
}
