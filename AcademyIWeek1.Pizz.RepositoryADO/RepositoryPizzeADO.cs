using AcademyIWeek1.Pizz.CORE.Entities;
using AcademyIWeek1.Pizz.CORE.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyIWeek1.Pizz.RepositoryADO
{
    public class RepositoryPizzeADO : IPizzeRepository
    {
        public List<Pizza> Fetch(List<Ingrediente> ingredienti, List<PizzaIngrediente> pizzeIngredienti)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetPizzeByIngrediente(Ingrediente ingredienteScelto)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetPizzeByIngrediente(Ingrediente ingredienteScelto, List<Ingrediente> ingredienti, List<PizzaIngrediente> pizzeIngredienti)
        {
            throw new NotImplementedException();
        }
    }
}
