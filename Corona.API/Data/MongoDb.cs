using Corona.API.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;

namespace Corona.API.Data
{
    public class MongoDb
    {
        public IMongoDatabase Db { get; set; }

        public MongoDb(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromConnectionString(configuration.GetConnectionString("Mongo"));
                var client = new MongoClient(settings);
                Db = client.GetDatabase(configuration["MongoConfigurations:Database"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível conectar ao mongoDB.", ex);
            }
        }

        private void MapClasses()
        {
            var conventionPack = new ConventionPack
            {
                new CamelCaseElementNameConvention()
            };

            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Infectado)))
            {
                BsonClassMap.RegisterClassMap<Infectado>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
