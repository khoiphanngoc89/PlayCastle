namespace PlayCastle.Common.SharedKernel.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string Host { get; init; }
        public int Port { get; init; }
        public string CollectionName { get; init; }

        public string ConnectionString => string.Format("mongodb://{0}:{1}", Host, Port);
    }
}