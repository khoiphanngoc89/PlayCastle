namespace Common.SharedKernel.Settings
{
    public interface ISerilogSettings
    {
        string LogstashgUrl { get; init; }
        string SeqServerUrl { get; init; }
    }
}