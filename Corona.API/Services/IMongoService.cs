using System.Collections.Generic;
using System.Threading.Tasks;

namespace Corona.API.Services
{
    public interface IMongoService<T> where T : class
    {
        Task<IEnumerable<T>> ObterTodos();
        Task Adicionar(T entity);
    }
}
