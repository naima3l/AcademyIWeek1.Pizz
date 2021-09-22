using AcademyIWeek1.Pizz.CORE.Entities;
using AcademyIWeek1.Pizz.CORE.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyIWeek1.Pizz.RepositoryMock
{
    public class RepositoryPizzeMock : IPizzeRepository
    {
        public static List<Pizza> pizze = new List<Pizza>()
        {
             new Pizza(1,"Margherita", 5),
             new Pizza (2, "Prosciutto e funghi",8),
             new Pizza (3, "Bufalina", 6),
            new Pizza(4, "Tirolese", 7)
        };

        public List<Pizza> Fetch()
        {
            return pizze;
        }

        public List<Pizza> Fetch(List<Ingrediente> ingredienti, List<PizzaIngrediente> pizzeIngredienti)
        {
            var pizze = Fetch();

            var matrix = (from pizza in pizze
                          join pizzaIngrediente in pizzeIngredienti on pizza.Id equals pizzaIngrediente.IdPizza
                          join ingrediente in ingredienti on pizzaIngrediente.IdIngrediente equals ingrediente.Id
                          select new PizzaWithIngrediente(pizza.Id, pizza.Nome, pizza.Prezzo, ingrediente.Nome));

            var pizzeWithIngredients = from row in matrix
                                       group row by new
                                       {
                                           row.IdPizza,
                                           row.Name,
                                           row.Price,
                                       } into listIngredienti
                                       select new Pizza()
                                       {
                                           Nome = listIngredienti.Key.Name,
                                           Id = listIngredienti.Key.IdPizza,
                                           Prezzo = listIngredienti.Key.Price,
                                           Ingredienti = listIngredienti.Select(i => i.NameIngrediente).ToList()
                                       };

            return pizzeWithIngredients.ToList();
        }

        public List<Pizza> GetPizzeByIngrediente(Ingrediente ingredienteScelto)
        {
            throw new NotImplementedException();
        }

        public struct PizzaWithIngrediente
        {
            public int IdPizza { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public string NameIngrediente { get; set; }

            public PizzaWithIngrediente(int idPizza, string name, double price, string nameIngrediente)
            {
                IdPizza = idPizza;
                Name = name;
                Price = price;
                NameIngrediente = nameIngrediente;
            }

        }
    }
}
