using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
/*using System.Data.Entity.Core;*/
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted
{
    public class Pruebas
    {
        [Key]
        public int PruebaId { get; set; }
        /*public int CasoId { get; set; }*/
        public bool Resultado { get; set; }
        /*public DateTime fecha { get; set; }
        public DateTime fechaResultado { get; set; }*/
        public Casos Casos { get; set; }

    }
}
