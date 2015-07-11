using Hurricane.Shared.Logging.Interfaces;

namespace Hurricane.Shared.Objects.Interfaces
{
    public interface IOutput
    {
        ILogger Log { get; }
    }
}