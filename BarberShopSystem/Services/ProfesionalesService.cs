using BarberShopSystem.Models;
using System.Linq;

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
                new Profesional { Id = 3, Nombre = "Laura Gómez", Correo = "laura@example.com", NumeroTelefono = "555-1234"},
                new Profesional { Id = 4, Nombre = "Carlos Rodríguez", Correo = "carlos@example.com", NumeroTelefono = "555-5678"},
                new Profesional { Id = 5, Nombre = "Ana Martínez", Correo = "ana@example.com", NumeroTelefono = "555-9876"}

            };

            return profesionales;
        }

        public void AgregarProfesional(Profesional nuevoProfesional)
        {
            List<Profesional> profesionales = ObtenerListaDeProfesionales();

            // Se obtiene el último Id existente
            int ultimoId = profesionales.Any() ? profesionales.Max(p => p.Id) : 0;

            // Asigna el nuevo Id al profesional
            nuevoProfesional.Id = ultimoId + 1;

            // Agrega el nuevo profesional a la lista
            profesionales.Add(nuevoProfesional);
        }
    }
}

