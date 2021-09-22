using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyIWeek1.Pizz.CORE.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<string> Ingredienti { get; set; }
        public double Prezzo { get; set; }

        public Pizza(int id, string nome, double prezzo)
        {
            Id = id;
            Nome = nome;
            Prezzo = prezzo;
        }
        public Pizza(int id, string nome, List<string> ingredienti, double prezzo)
        {
            Id = id;
            Nome = nome;
            Ingredienti = ingredienti;
            Prezzo = prezzo;
        }

        public Pizza()
        {

        }

        public string Print()
        {
            string ingredientiString = string.Empty;
            foreach (var ingrediente in Ingredienti)
            {
                ingredientiString = String.Concat(ingredientiString + " - " + ingrediente);
            }
            return $"{Nome} {ingredientiString} - {Prezzo}";
        }

        public string PrintWithOutIngredienti() => $"{Nome} - {Prezzo}";
    }
}
