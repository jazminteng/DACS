using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            var paciente1 = new Pacientes { Dni = 41000001 ,
                                           Nombre = "Martin",
                                            Apellido = "Yaoming"};
            var paciente2 = new Pacientes { Dni = 41000002 ,
                                            Nombre = "Juan",
                                            Apellido = "Bo"};
            var paciente3 = new Pacientes { Dni = 41000003 ,
                                            Nombre = "Jazmin",
                                            Apellido = "Flores"};


            var medico1 = new Medicos { Matricula = 10001, Nombre = "Ezequiel", Apellido = "Del Peru"};
            var medico2 = new Medicos { Matricula = 10002, Nombre = "Hernan", Apellido = "Troncoso"};

            var caso1 = new Casos { Estado = "En prueba", Medicos = medico1, Pacientes = paciente1};
            var caso2 = new Casos { Estado = "Sospechoso", Medicos = medico1, Pacientes = paciente2};
            var caso3 = new Casos { Estado = "Saludable", Medicos = medico2, Pacientes = paciente3};

            var consulta1 = new Consultas { DescripcionSintomas = "catarro, diarrea" };
            var consulta2 = new Consultas { DescripcionSintomas = "estornudos, fiebre" };
            var consulta3 = new Consultas { DescripcionSintomas = "estornudos, fiebre" };

            medico1.Consultas.Add(consulta1);
            medico1.Consultas.Add(consulta2);
            medico2.Consultas.Add(consulta3);
            paciente1.Consultas.Add(consulta1);
            paciente2.Consultas.Add(consulta2);
            paciente3.Consultas.Add(consulta3);

            using (var db = new HPContext())
            {

                //Insercion de en la base de datos, esto solo debe hacerse una vez
                db.Add(caso1);
                db.Add(caso2);
                db.Add(caso3);
                db.Add(paciente1);
                db.Add(paciente2);
                db.Add(paciente3);
                db.Add(medico1);
                db.Add(medico2);
                db.Add(consulta1);
                db.Add(consulta2);
                db.Add(consulta3);
                db.SaveChanges();


                Console.WriteLine("Listando todos los casos en la BBDD");
                var casos = db.Casos
                    .OrderBy(c => c.CasoId)
                    .ToList();
                
                foreach (Casos caso in casos){
                    Console.WriteLine("Numero de caso: ");
                    Console.WriteLine(caso.CasoId);
                    Console.WriteLine("Paciente del caso: ");
                    Console.WriteLine(caso.Pacientes.Dni);
                    Console.WriteLine("Medico encargado: ");
                    Console.WriteLine(caso.Medicos.Matricula);
                    Console.WriteLine("////////////////////////////");
                }
                
                Console.WriteLine("////////////////////////////");
                Console.WriteLine("----------------------------");
                Console.WriteLine("////////////////////////////");
            

                Console.WriteLine("Leyendo las consultas asignadas al medico1");
                var consultas = db.Consultas
                    .Where(c => c.Medicos.Matricula == medico1.Matricula)
                    .OrderBy(c => c.ConsultaId)
                    .ToList();

                foreach (Consultas consulta in consultas){
                    Console.WriteLine("Numero de consulta: ");
                    Console.WriteLine(consulta.ConsultaId);
                    Console.WriteLine("Paciente del caso: ");
                    Console.WriteLine(consulta.Pacientes.Dni);
                    Console.WriteLine("Medico encargado: ");
                    Console.WriteLine(consulta.Medicos.Matricula);
                    Console.WriteLine("////////////////////////////");
                }



                //Ejemplo actualizacion
                Console.WriteLine("Medico1 de licencia, se asigna al medico2 a los casos del medico1");
                var casosAsignar = db.Casos
                    .Where(c => c.Medicos.Matricula == 10001)
                    .ToList();
                var medAsignar = db.Medicos
                    .Where(m => m.Matricula == 10002)
                    .ToList();
                foreach (Casos casoa in casosAsignar){
                    Console.WriteLine("Asignando caso {0} a medico2",casoa.CasoId);
                    casoa.Medicos = medAsignar[0];
                    Console.WriteLine(medAsignar[0].Matricula);
                    db.SaveChanges();
                }
                
                Console.WriteLine("Leyendo los casos asignadas al medico2");
                var cas = db.Casos
                    .Where(c => c.Medicos.Matricula == medico2.Matricula)
                    .OrderBy(c => c.CasoId)
                    .ToList();
                foreach (Casos casoss in cas){
                    Console.WriteLine("Numero del caso: ");
                    Console.WriteLine(casoss.CasoId);
                    Console.WriteLine("Paciente del caso: ");
                    Console.WriteLine(casoss.Pacientes.Dni);
                    Console.WriteLine("Medico encargado: ");
                    Console.WriteLine(casoss.Medicos.Matricula);
                    Console.WriteLine("////////////////////////////");
                }
            }
        }
    }
}