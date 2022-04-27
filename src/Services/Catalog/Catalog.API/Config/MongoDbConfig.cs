using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using MongoDB.Driver;
using Common.SharedKernel.Settings;

namespace Catalog.API.Config
{
    public static class MongoDbConfig
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IMongoDbSettings mongoDbSettings, IServiceSettings serviceSettings)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(serviceSettings.ServiceName);

            services.AddSingleton<IMongoDatabase>(mongoDatabase);

            return services;
        }
    }
    
}