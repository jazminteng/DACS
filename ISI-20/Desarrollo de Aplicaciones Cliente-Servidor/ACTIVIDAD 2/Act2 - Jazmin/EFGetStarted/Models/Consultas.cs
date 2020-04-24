using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
/*using System.Data.Entity.Core;*/
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted
{
    public class Consultas
    {
        [Key]
        public int ConsultaId { get; set; }
        /*public int PacienteId { get; set; }*/
        /*public int MedicoId { get; set; }*/
        /*public string profesional { get; set; }*/
        public string DescripcionSintomas { get; set; }
        public string Diagnostico { get; set; }
        /*public DateTime fecha { get; set; }*/
        public Medicos Medicos { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}
