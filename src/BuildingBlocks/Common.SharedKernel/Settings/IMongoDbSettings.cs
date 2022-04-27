namespace Common.SharedKernel.Settings
{
    public interface IMongoDbSettings
    {
        string CollectionName { get; init; }
        string ConnectionString { get; }
        string Host { get; init; }
        int Port { get; init; }
    }
}