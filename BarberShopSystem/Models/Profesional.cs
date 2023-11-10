﻿namespace BarberShopSystem.Models
{
    public class Profesional
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? NumeroTelefono { get; set; }

        // Relación con otras tablas
        public List<Reserva>? Reservas { get; set; }
        public List<Cupo>? Cupos { get; set; }
        public List<ProfesionalServicio>? ProfesionalServicios { get; set; }
    }
}
