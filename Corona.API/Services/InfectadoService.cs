using Corona.API.Data;
using Corona.API.Data.Collections;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Corona.API.Services
{
    public class InfectadoService : MongoService<Infectado>, IInfectadoService
    {
        public InfectadoService(MongoDb mongoDb) : base(mongoDb)
        {
        }

        public Infectado ObterPorId(Guid id)
        {
            return _collection.AsQueryable().FirstOrDefault(x => x.Id == id);
        }
    }
}
