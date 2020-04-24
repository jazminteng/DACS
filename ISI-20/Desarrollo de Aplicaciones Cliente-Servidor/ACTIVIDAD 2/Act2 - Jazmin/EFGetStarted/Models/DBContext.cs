using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class HPContext : DbContext
    {
        public DbSet<Casos> Casos { get; set; }
        public DbSet<Consultas> Consultas { get; set; }
        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Pruebas> Pruebas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Casos>()
            .HasOne(b => b.Pacientes)
            .WithOne(i => i.Casos)
            .HasForeignKey<Pacientes>(b => b.CasosForeignKey);
    }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Hospital.db");
    }
}
