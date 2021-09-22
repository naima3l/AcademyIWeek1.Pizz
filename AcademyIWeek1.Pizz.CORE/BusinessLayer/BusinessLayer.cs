using AcademyIWeek1.Pizz.CORE.Entities;
using AcademyIWeek1.Pizz.CORE.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyIWeek1.Pizz.CORE.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IPizzeRepository pizzeRepo;
        private readonly IIngredientiRepository ingredientiRepo;
        private readonly IPizzeIngredientiRepository pizzeIngredientiRepo;

        public delegate double Sconto(List<Pizza> pizze);

        public BusinessLayer(IPizzeRepository pizze, IIngredientiRepository ingredienti, IPizzeIngredientiRepository pizzeIngredienti)
        {
            pizzeRepo = pizze;
            ingredientiRepo = ingredienti;
            pizzeIngredientiRepo = pizzeIngredienti;
        }

        public double CalcolaConto(List<Pizza> pizzeScelte)
        {
            Sconto sconto = CalcolaSconto;
            return pizzeScelte.Sum(p => p.Prezzo) - sconto(pizzeScelte);
        }
        public static double CalcolaSconto(List<Pizza> pizze)
        {
            if (FirstScount(pizze) > SecondScount(pizze))
                return FirstScount(pizze);
            else
                return SecondScount(pizze);
        }
        public static double FirstScount(List<Pizza> pizze)
        {
            if (pizze.Count() > 2)
                //return pizze.Select(p => p.Prezzo).Min();
                return pizze.Min(p => p.Prezzo);
            else
                return 0;
        }
        public static double SecondScount(List<Pizza> pizze)
        {
            var total = pizze.Sum(p => p.Prezzo);
            if (total >= 50)
                return total * 10 / 100;
            else
                return 0;
        }


        public List<Ingrediente> FetchIngredienti()
        {
            return ingredientiRepo.Fetch();
        }

        public List<Pizza> FetchPizze()
        {
            #region MenuDaFile

            //const string path = @"C:\Users\arian\Desktop\AcademyI.Week1\Menu.txt";

            //string menu = string.Empty;

            //using (StreamReader sr = new StreamReader(path))
            //{
            //    menu = sr.ReadToEnd();
            //}

            //// Margherita 0
            //// pomodoro, mozzarella 1
            //// 5 2

            //// Vegetariana - pomodoro, mozzarella, zucchine, peperoni - 7
            //// Bufalina - pomodoro, mozzarella di bufala - 6"


            //var righe = menu.Split("\r\n");

            //List<Pizza> pizze = new List<Pizza>();

            //foreach (var riga in righe)
            //{
            //    var pizzaArray = riga.Split("-");

            //    Pizza pizza = new Pizza();
            //    pizza.Nome = pizzaArray[0].Trim();
            //    pizza.Prezzo = Convert.ToDouble(pizzaArray[2].Trim());
            //    List<string> ingredienti = new List<string>();
            //    var ingredientiArray = pizzaArray[1].Split(",");
            //    foreach (var ingrediente in ingredientiArray)
            //    {
            //        ingredienti.Add(ingrediente.Trim());
            //    }
            //    pizza.Ingredienti = ingredienti;

            //    pizze.Add(pizza);
            //}

            //return pizze;

            #endregion

            var ingredienti = ingredientiRepo.Fetch();
            var pizzeIngredienti = pizzeIngredientiRepo.Fetch();
            return pizzeRepo.Fetch(ingredienti, pizzeIngredienti);
        }

        public void StampaScontrino(List<Pizza> pizzeScelte)
        {
            Double totale = CalcolaConto(pizzeScelte);

            const string path = @"C:\Users\naima.el.khattabi\Desktop\Cart.txt";

            using (StreamWriter sw1 = new StreamWriter(path))
            {
                sw1.WriteLine("*** SCONTRINO ***");
            }

            foreach (var pizza in pizzeScelte)
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(pizza.PrintWithOutIngredienti());
                }
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine("-------------------");
                sw.WriteLine($"TOTALE                 {totale}");
            }
        }

        public List<Pizza> GetPizzeByIngrediente(Ingrediente ingredienteScelto)
        {
            return pizzeRepo.GetPizzeByIngrediente(ingredienteScelto);
        }
    }
}
