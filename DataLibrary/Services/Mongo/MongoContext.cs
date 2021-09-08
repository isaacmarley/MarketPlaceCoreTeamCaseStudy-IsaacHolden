using DataLibrary.MongoSerializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Services.Mongo
{
    public class MongoContext : IMongoContext
    {
        private const String DATABASE_NAME = "MarketplaceCoreTeamCaseStudy";

        private readonly IMongoClient _MongoClient;
        public ISerializers _Serializers { get; }

        public MongoContext(IMongoClient mongoClient, ISerializers serializers)
        {
            _MongoClient = mongoClient;
            _Serializers = serializers;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _MongoClient.GetDatabase(DATABASE_NAME).GetCollection<T>(typeof(T).Name);
        }
    }
}
