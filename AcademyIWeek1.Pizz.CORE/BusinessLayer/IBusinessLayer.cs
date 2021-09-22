using AcademyIWeek1.Pizz.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyIWeek1.Pizz.CORE.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<Pizza> FetchPizze();
        List<Ingrediente> FetchIngredienti();
        double CalcolaConto(List<Pizza> pizzeScelte);
        void StampaScontrino(List<Pizza> pizzeScelte);
        List<Pizza> GetPizzeByIngrediente(Ingrediente ingredienteScelto);
    }
}
