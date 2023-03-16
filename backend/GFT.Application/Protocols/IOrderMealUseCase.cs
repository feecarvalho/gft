using GFT.Application.Results;

namespace GFT.Application.Protocols
{
    public interface IOrderMealUseCase
    {
        public UseCaseResult<string> Execute(string input);
    }
}
