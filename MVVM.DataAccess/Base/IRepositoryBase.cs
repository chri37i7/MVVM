using MVVM.DataAccess.Entities.Models;
using System.Collections.Generic;

namespace MVVM.DataAccess.Base
{
    public interface IRepositoryBase<T>
    {
        NorthwindContext Context { get; set; }

        IEnumerable<T> GetAll();

        T GetBy(int id);

        void Update();
        void Add(T t);
        void Delete(T t);
    }
}