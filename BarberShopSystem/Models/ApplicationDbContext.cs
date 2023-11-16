using Microsoft.EntityFrameworkCore;

namespace BarberShopSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cupo> Cupos { get; set; }
        public DbSet<Profesional> Profesionales { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<ProfesionalServicio> ProfesionalServicios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relaciones para ProfesionalServicio
            modelBuilder.Entity<ProfesionalServicio>()
                .HasKey(ps => new { ps.ProfesionalId, ps.ServicioId });

            modelBuilder.Entity<ProfesionalServicio>()
                .HasOne(ps => ps.Profesional)
                .WithMany(p => p.ProfesionalServicios)
                .HasForeignKey(ps => ps.ProfesionalId);

            modelBuilder.Entity<ProfesionalServicio>()
                .HasOne(ps => ps.Servicio)
                .WithMany(s => s.ProfesionalServicios)
                .HasForeignKey(ps => ps.ServicioId);

            // Relaciones para Reserva
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClienteId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cupo)
                .WithOne(c => c.Reserva)
                .HasForeignKey<Reserva>(r => r.CupoId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Servicio)
                .WithMany()
                .HasForeignKey(r => r.ServicioId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Profesional)
                .WithMany(p => p.Reservas)
                .HasForeignKey(r => r.ProfesionalId);

            // Relaciones para Profesional
            modelBuilder.Entity<Profesional>()
                .HasMany(p => p.Cupos)
                .WithOne(c => c.Profesional)
                .HasForeignKey(c => c.ProfesionalId);

            modelBuilder.Entity<Profesional>()
                .HasMany(p => p.ProfesionalServicios)
                .WithOne(ps => ps.Profesional)
                .HasForeignKey(ps => ps.ProfesionalId);
        }
    }
}
