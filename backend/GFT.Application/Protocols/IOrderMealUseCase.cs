using GFT.Application.Results;

namespace GFT.Application.Protocols
{
    public interface IOrderMealUseCase : IUseCase<UseCaseResult<Dictionary<string, string>>, string>
    {
    }
}
