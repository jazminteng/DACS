using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
/*using System.Data.Entity.Core;*/
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted
{
    public class Casos
    {
        [Key]
        public int CasoId { get; set; }
        /*public int idpaciente { get; set; }*/
        /*public int MedicoId { get; set; }*/
        public string Estado { get; set; }
        public Medicos Medicos { get; set; }
        public Pacientes Pacientes { get; set; }
        public List<Pruebas> Pruebas { get; set; }
        public Casos()
        {
            Pruebas = new List<Pruebas>();
        }

        /*public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();*/
    }
}