using BilisimKreatif.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BilisimKreatif.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(params string[] nav);
        Task<IEnumerable<T>> GetManyAsync(Func<T, bool> where, Func<T, object> orderby, bool desc = false, params string[] nav);
        Task<T> GetAsync(string id, params string[] nav);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        Task<bool> AnyAsync(System.Linq.Expressions.Expression<Func<T, bool>> where);
    }
}
