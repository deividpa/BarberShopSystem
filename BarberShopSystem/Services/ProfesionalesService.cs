using BarberShopSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BarberShopSystem.Services
{
    // (Inyección de dependencias: SOLID) Este servicio se encarga de obtener la lista de profesionales desde la base de datos o cualquier otra fuente de datos.

    public class ProfesionalesService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfesionalesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Profesional> ObtenerListaDeProfesionales()
        {
            return _dbContext.Profesionales.ToList();
        }

        public void AgregarProfesional(Profesional nuevoProfesional)
        {
            _dbContext.Profesionales.Add(nuevoProfesional);
            _dbContext.SaveChanges();
        }
    }
}

