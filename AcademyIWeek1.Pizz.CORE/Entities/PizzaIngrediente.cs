using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyIWeek1.Pizz.CORE.Entities
{
    public class PizzaIngrediente
    {
        public int IdPizza { get; set; }
        public int IdIngrediente { get; set; }

        public PizzaIngrediente(int idPizza, int idIngrediente)
        {
            IdPizza = idPizza;
            IdIngrediente = idIngrediente;
        }
    }
}
