using System.Collections.Generic;

namespace LandisGyrProject.Services
{
    public interface IService<T>
    {
        string Create(T item);
        IEnumerable<T> ListAll();
        string Update(string id, T item);
        string Delete(string id);
        T Find(string id);
    }
}
