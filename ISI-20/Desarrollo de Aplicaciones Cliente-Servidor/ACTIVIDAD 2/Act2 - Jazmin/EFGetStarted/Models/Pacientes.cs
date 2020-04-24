using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
/*using System.Data.Entity.Core;*/
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted
{
    public class Pacientes
    {
        [Key]
        public int PacienteId { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        /*public DateTime fechaNac { get; set; }*/
        public int CasosForeignKey { get; set; }
        public List<Consultas> Consultas { get; set; } 
        /*public ICollection<Consultas> Consultas { get; set; }*/
        public Casos Casos { get; set; }
        public Pacientes()
        {
            Consultas = new List<Consultas>();
        }
        /*public ICollection<Casos> Casos { get; set; }*/
    }
}
