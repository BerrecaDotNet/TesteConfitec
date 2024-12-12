using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteConfitec.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task Insert(T entity);
        Task Update(int Id, T entity);
        Task Delete(int Id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
    }
}
