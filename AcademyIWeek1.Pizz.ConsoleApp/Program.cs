using AcademyIWeek1.Pizz.CORE.BusinessLayer;
using AcademyIWeek1.Pizz.CORE.Entities;
using AcademyIWeek1.Pizz.RepositoryMock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyIWeek1.Pizz.ConsoleApp
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryPizzeMock(), new RepositoryIngredientiMock(), new RepositoryPizzeIngredientiMock());
        private static List<Pizza> pizzeScelte = new List<Pizza>();
        static void Main(string[] args)
        {
            bool continua = true;

            do
            {
                Console.WriteLine("1. Scegli pizze dal menu generale");
                Console.WriteLine("2. Visualizza le pizze per ingrediente");
                Console.WriteLine("0. Exit");

                int scelta;
                Console.Write("Inserisci scelta: ");
                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 2)
                {
                    Console.Write("\nScelta errata. Inserisci scelta corretta: ");
                }

                switch (scelta)
                {
                    case 0:
                        continua = false;
                        break;
                    case 1:
                        ChoosePizza();
                        break;
                    case 2:
                        ShowPizzaByIngrediente();
                        break;

                }

            } while (continua);
        }

        private static void ChoosePizza()
        {
            List<Pizza> pizze = bl.FetchPizze();
            PrintPizze(pizze);
            bool continuare = true;
            do
            {
                Console.WriteLine("Scegli una pizza");
                string tipoPizza = Console.ReadLine();
                var pizza = pizze.Where(p => p.Nome == tipoPizza).SingleOrDefault();
                if (pizza == null)
                {
                    Console.WriteLine("Pizza inesistente");
                }
                else
                {
                    pizzeScelte.Add(pizza);
                }

                Console.WriteLine("Vuoi aggiungere un'altra pizza?\n Premi S per si");
                var scelta = Console.ReadKey();
                continuare = ConsoleKey.S.Equals(scelta.Key);
                Console.WriteLine();
            }
            while (continuare);

            bl.StampaScontrino(pizzeScelte);
        }
        private static void PrintPizze(List<Pizza> pizze)
        {
            foreach (var pizza in pizze)
            {
                Console.WriteLine(pizza.Print());
            }
        }
        private static void PrintIngredienti(List<Ingrediente> ingredienti)
        {
            foreach (var ingrediente in ingredienti)
            {
                Console.WriteLine(ingrediente);
            }
        }


        private static void ShowPizzaByIngrediente()
        {
            List<Ingrediente> ingredienti = bl.FetchIngredienti();
            PrintIngredienti(ingredienti);
            bool continuare = true;
            do
            {
                Console.WriteLine("Scegli un ingrediente");
                string ingrediente = Console.ReadLine();
                var ingredienteScelto = ingredienti.Where(i => i.Nome == ingrediente).SingleOrDefault();
                //Fare il controllo che esista anche nella associazione pizze - ingredienti

                if (ingredienteScelto == null)
                {
                    Console.WriteLine("Nessuna pizza contiene questo ingrediente");
                }
                else
                {
                    var pizzePossibili = bl.GetPizzeByIngrediente(ingredienteScelto);
                    if (pizzePossibili.Count == 0)
                    {
                        Console.WriteLine($"Non ci sono pizze con ingrediente {ingredienteScelto}");
                    }
                    else
                    {
                        Console.WriteLine($"Le pizze con ingrediente {ingredienteScelto} sono : ");
                        PrintPizze(pizzePossibili);
                    }
                    continuare = false;
                }

                //Console.WriteLine("Vuoi aggiungere un'altra pizza?\n Premi S per si");
                //var scelta = Console.ReadKey();
                //continuare = ConsoleKey.S.Equals(scelta.Key);
                //Console.WriteLine();
            }
            while (continuare);

            //bl.StampaScontrino(pizzeScelte);


        }
    }
}
