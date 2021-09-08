using MongoDB.Driver;

namespace DataLibrary.Services.Mongo
{
    public interface IMongoContext
    {
        IMongoCollection<T> GetCollection<T>();
    }
}