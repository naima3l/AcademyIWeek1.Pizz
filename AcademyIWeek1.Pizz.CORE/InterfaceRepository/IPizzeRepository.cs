using AcademyIWeek1.Pizz.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyIWeek1.Pizz.CORE.InterfaceRepository
{
    public interface IPizzeRepository : IRepository<Pizza>
    {
        public List<Pizza> Fetch(List<Ingrediente> ingredienti, List<PizzaIngrediente> pizzeIngredienti);
        List<Pizza> GetPizzeByIngrediente(Ingrediente ingredienteScelto);
    }
}
