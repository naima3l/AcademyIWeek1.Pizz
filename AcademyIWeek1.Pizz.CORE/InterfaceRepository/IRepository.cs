using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyIWeek1.Pizz.CORE.InterfaceRepository
{
    public interface IRepository<T>
    {
        public List<T> Fetch();
    }
}
