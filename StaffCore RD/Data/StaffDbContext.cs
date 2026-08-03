using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StaffCoreRD.Models;
using System.Reflection.Emit;

namespace StaffCoreRD.Data
{
    public class StaffDbContext : IdentityDbContext
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options)
            : base(options)
        {
        }

        public DbSet<Staff> Personal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data - 2 empleados de departamentos distintos
            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 1,
                    Nombre = "Juan Carlos Pérez",
                    Cedula = "001-1234567-8",
                    Cargo = "Jefe de Tecnología",
                    Departamento = "Tecnología",
                    Salario = 50000,
                    FechaIngreso = new DateTime(2023, 1, 15),
                    Activo = true
                },
                new Staff
                {
                    Id = 2,
                    Nombre = "María Martínez Rodríguez",
                    Cedula = "002-9876543-2",
                    Cargo = "Especialista de RRHH",
                    Departamento = "Recursos Humanos",
                    Salario = 35000,
                    FechaIngreso = new DateTime(2023, 3, 20),
                    Activo = true
                }
            );
        }
    }
}