using GFT.Application.Protocols;
using GFT.Application.Results;
using GFT.Application.Validators;
using GFT.Domain.Entities;
using GFT.Domain.ValueObjects;

namespace GFT.Application.UseCases
{
    public class OrderMealUseCase : IOrderMealUseCase
    {
        public UseCaseResult<string> Execute(string input)
        {
            var mealOrder = input.Split(',');
            var dayTime = new DayTime(mealOrder[0]);
            var dishesList = mealOrder.Skip(1).ToList();
            var order = new Order(dayTime, dishesList);
            var dishes = GenerateMeal.GenerateDishes(order);
            var preparedMealList = dishes.OrderBy(d => d.Key).Select(k => k.Value).Distinct().ToList();
            var result = string.Join(", ", preparedMealList);
            return new UseCaseResult<string>(result);
        }
    }
}
