using BarberShopSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BarberShopSystem.Services
{
    public class ServiciosService
    {
        private readonly ApplicationDbContext _dbContext;

        public ServiciosService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Servicio> ObtenerListaDeServicios()
        {
            return _dbContext.Servicios.ToList();
        }

        public void AgregarServicio(Servicio nuevoServicio)
        {
            _dbContext.Servicios.Add(nuevoServicio);
            _dbContext.SaveChanges();
        }

        public Servicio ObtenerServicioPorId(int id)
        {
            return _dbContext.Servicios.FirstOrDefault(s => s.Id == id) ?? new Servicio();
        }
    }
}