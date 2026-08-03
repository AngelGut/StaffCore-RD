using System.ComponentModel.DataAnnotations;

namespace StaffCoreRD.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }  // Nombre completo

        [Required(ErrorMessage = "La cédula es requerida")]
        [RegularExpression(@"^\d{3}-\d{7}-\d{1}$",
            ErrorMessage = "Formato de cédula inválido (001-0000000-0)")]
        public string Cedula { get; set; }  // Formato: 001-0000000-0

        [Required(ErrorMessage = "El cargo es requerido")]
        public string Cargo { get; set; }  // Ej: Analista de Sistemas

        [Required(ErrorMessage = "El departamento es requerido")]
        public string Departamento { get; set; }  // Tecnología / RRHH / Finanzas / Operaciones

        [Required(ErrorMessage = "El salario es requerido")]
        [Range(23223, double.MaxValue, ErrorMessage = "Mínimo RD$23,223")]
        public decimal Salario { get; set; }

        public DateTime FechaIngreso { get; set; }

        public bool Activo { get; set; } = true;
    }
}