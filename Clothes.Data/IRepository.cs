using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Data
{
    public interface IRepository<T>
    {
        void Create(T entity);

        ICollection<T> ReadAll();

        T Read(int id);

        void Update(T entity);

        void Delete(T entity);
    }
}
