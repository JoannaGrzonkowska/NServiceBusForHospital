using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryClasses
{
    public interface IRepository<TModel>
       where TModel : class
    {
        void Add(TModel entity);
        void Delete(TModel entity);
        IEnumerable<TModel> GetAll();
        IQueryable<TModel> GetAllQueryable();
        TModel GetById(int id);
    }
}
