namespace BarberShopSystem.Models
{
    public class Cupo
    {
        public Cupo()
        {
            Reserva = new Reserva();
        }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public bool EstadoCupo { get; set; }
        public int ServiciosDisponibles { get; set; }

        // Relaciones con otras tablas
        public int ProfesionalId { get; set; }
        public Profesional? Profesional { get; set; }

        public Reserva Reserva { get; set; }

        // Método para verificar si el cupo está dentro del horario permitido
        public bool EstaEnHorarioPermitido()
        {
            // Define el rango horario permitido (de 8am a 5pm)
            DateTime horaInicioPermitida = new DateTime(Fecha.Year, Fecha.Month, Fecha.Day, 8, 0, 0);
            DateTime horaFinPermitida = new DateTime(Fecha.Year, Fecha.Month, Fecha.Day, 17, 0, 0);

            return HoraInicio >= horaInicioPermitida && HoraFin <= horaFinPermitida;
        }
    }
}
