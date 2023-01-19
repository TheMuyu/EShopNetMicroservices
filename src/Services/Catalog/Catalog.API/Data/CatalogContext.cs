using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var a = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            var b = configuration.GetValue<string>("DatabaseSettings:DatabaseName");
            var c = configuration.GetValue<string>("DatabaseSettings:ProductCollection");
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:ProductCollection"));
            CatalogContextSeed.SeedProduct(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}