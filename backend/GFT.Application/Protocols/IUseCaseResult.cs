using GFT.Application.Results;

namespace GFT.Application.Protocols
{
    public interface IUseCaseResult
    {
        ResultStatus Status { get; }
        IEnumerable<string> Errors { get; }
        object GetValue();
    }
}
