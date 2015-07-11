using Hurricane.Shared.Logging;

namespace Hurricane.Shared.Objects
{
    public interface IOutput
    {
        ILogger Log { get; } 
    }
}