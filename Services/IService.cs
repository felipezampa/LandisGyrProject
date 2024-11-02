using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandisGyrProject.Services
{
    public interface IService<T>
    {
        string Create(T item);
        IEnumerable<T> ListAll();
        void Update(string id, T item);
        string Delete(string id);
        T Find(Func<T, bool> predicate);
    }
}
