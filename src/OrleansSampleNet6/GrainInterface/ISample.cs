using Orleans;

namespace GrainInterface;

public interface ISample : IGrainWithStringKey
{
    Task<string> Response(string message);
}