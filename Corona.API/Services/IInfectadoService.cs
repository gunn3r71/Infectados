using Corona.API.Data.Collections;
using System;
using System.Threading.Tasks;

namespace Corona.API.Services
{
    public interface IInfectadoService : IMongoService<Infectado>
    {
        Infectado ObterPorId(Guid id);
    }
}
