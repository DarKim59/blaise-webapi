namespace Blaise.Api.Interfaces
{
    public interface IConfigurationProvider
    {
        string ProjectId { get; }

        string ServiceName { get; }

        string ServiceVersion { get; }
    }
}