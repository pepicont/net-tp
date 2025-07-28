using System.Numerics;
using Domain.model;


namespace DataDomain
{
    public class InMemory
    {
        public static List<Especialidad> especialidades;

        public static List<Plan> planes;

        static InMemory()
        {
            especialidades = new List<Especialidad>
            {
                new Especialidad(1,"descripción 1"),
                new Especialidad(2,"descripción 2"),
                new Especialidad(3,"descripción 3"),
                new Especialidad(4,"descripción 4"),
                new Especialidad(5,"descripción 5"),
            };

            planes = new List<Plan>
            {
                new Plan(1, "sape", 1),
                new Plan(2, "sape", 1),
                new Plan(3, "sape", 3),
                new Plan(4, "sape", 3)
            };
        }




    }
}