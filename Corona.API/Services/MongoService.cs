using System.Linq;
using Corona.API.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Corona.API.Services
{
    public abstract class MongoService<T> : IMongoService<T> where T : class
    {
        private readonly MongoDb _mongoDb;
        protected IMongoCollection<T> _collection;

        public MongoService(MongoDb mongoDb)
        {
            _mongoDb = mongoDb;

            _collection = _mongoDb.Db.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public async Task Adicionar(T entity) => await _collection.InsertOneAsync(entity);

        public async Task<IEnumerable<T>> ObterTodos()
        {
            var result = await _collection.FindAsync<T>(Builders<T>.Filter.Empty);
            return result.ToList();
        }
    }
}
