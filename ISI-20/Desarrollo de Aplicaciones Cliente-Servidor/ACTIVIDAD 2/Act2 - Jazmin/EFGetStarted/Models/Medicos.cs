using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
/*using System.Data.Entity.Core;*/
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted
{
    public class Medicos
    {
        [Key]
        /*public int MedicosId { get; set; }*/
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<Consultas> Consultas { get; set; }
        public List<Casos> Casos { get; set; }
        public Medicos()
        {
            Consultas = new List<Consultas>();
            Casos = new List<Casos>();
        }
    } 
}
