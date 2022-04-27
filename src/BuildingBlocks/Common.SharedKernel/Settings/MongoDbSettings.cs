namespace Common.SharedKernel.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string Host { get; init; }
        public int Port { get; init; }
        public string CollectionName { get; init; }

        // https://stackoverflow.com/questions/71921208/cant-connect-to-mongodb-in-docker-container
        // container name of mongo db must be the same with host name
        public string ConnectionString => string.Format("mongodb://{0}:{1}", Host, Port);
    }
}