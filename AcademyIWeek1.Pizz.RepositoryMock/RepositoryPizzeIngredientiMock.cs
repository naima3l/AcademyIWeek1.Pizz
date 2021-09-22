using AcademyIWeek1.Pizz.CORE.Entities;
using AcademyIWeek1.Pizz.CORE.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyIWeek1.Pizz.RepositoryMock
{
    public class RepositoryPizzeIngredientiMock : IPizzeIngredientiRepository
    {
        public static List<PizzaIngrediente> pizzeIngredienti = new List<PizzaIngrediente>()
        {
            new PizzaIngrediente(1, 1),
            new PizzaIngrediente(1, 2),
            new PizzaIngrediente(3, 1),
            new PizzaIngrediente(3, 5),
            new PizzaIngrediente(2, 1),
            new PizzaIngrediente(2, 2),
            new PizzaIngrediente(2, 3),
            new PizzaIngrediente(2, 4),
            new PizzaIngrediente(4, 1),
            new PizzaIngrediente(4, 2),
            new PizzaIngrediente(4, 6),
        };

        public List<PizzaIngrediente> Fetch()
        {
            return pizzeIngredienti;
        }
    }
}
