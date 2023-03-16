using GFT.Application.Protocols;
using GFT.Application.Results;

namespace GFT.Application.UseCases
{
    public class OrderMealUseCase : IOrderMealUseCase
    {
        public UseCaseResult<string> Execute(string input)
        {
            var validateMeal = input.Split(',');
            if (validateMeal.Length == 1)
            {
                return UseCaseResult<string>.Invalid("");
            }

            return UseCaseResult<string>.Success("");
        }
    }
}
