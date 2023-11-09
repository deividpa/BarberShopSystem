using BarberShopSystem.Models;

namespace BarberShopSystem.Services
{
    // (Inyección de dependencias: SOLID) Este servicio se encarga de obtener la lista de profesionales desde la base de datos o cualquier otra fuente de datos.

    public class ProfesionalesService
    {
        // Método para obtener la lista de reservas
        public List<Profesional> ObtenerListaDeProfesionales()
        {
            // Simulación de obtención de datos (actualmente no se extrae info de la BD)
            List<Profesional> profesionales = new List<Profesional>
            {
                new Profesional { Id = 1, Nombre = "Marisol Pérez", Especialidad = "Peluquería" },
                new Profesional { Id = 2, Nombre = "Danilo Cifuentes" , Especialidad = "Barbería" },
            };

            return profesionales;
        }
    }
}
