using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyIWeek1.Pizz.CORE.Entities
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Ingrediente(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
