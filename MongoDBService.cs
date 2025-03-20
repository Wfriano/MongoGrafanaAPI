using MongoDB.Driver;
using MongoGrafanaAPI.Models;
using Microsoft.Extensions.Options;

namespace MongoGrafanaAPI.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<TransactionLog> _collection;

        public MongoDBService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _collection = database.GetCollection<TransactionLog>(config["MongoDB:CollectionName"]);
        }

        public async Task<List<TransactionLog>> GetFilteredAsync(string transactionId, string type, DateTime start, DateTime end)
        {
            var filter = Builders<TransactionLog>.Filter.And(
                Builders<TransactionLog>.Filter.Eq(t => t.TransactionId, transactionId),
                Builders<TransactionLog>.Filter.Eq(t => t.Type, type),
                Builders<TransactionLog>.Filter.Gte(t => t.Timestamp, start),
                Builders<TransactionLog>.Filter.Lte(t => t.Timestamp, end)
            );

            return await _collection.Find(filter).ToListAsync();
        }
    }
}
