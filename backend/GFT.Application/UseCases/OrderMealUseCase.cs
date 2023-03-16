using GFT.Application.Protocols;
using GFT.Application.Results;
using GFT.Application.Validators;
using GFT.Domain.Entities;

namespace GFT.Application.UseCases
{
    public class OrderMealUseCase : IOrderMealUseCase
    {
        public UseCaseResult<Dictionary<string, string>> Execute(string input)
        {
            var orderErrors = OrderValidator.ValidateOrder(input);

            if (orderErrors.Any())
            {
                return UseCaseResult<Dictionary<string, string>>.Invalid(orderErrors);
            }

            var order = new Order(input);
            if (order.DayTime.Value.ToLower() == "morning")
            {
                var morningDishes = ValidateMorningDishes(order.Requests);
                return UseCaseResult<Dictionary<string,string>>.Success(morningDishes);
            }

            return UseCaseResult<Dictionary<string, string>>.Success(new Dictionary<string, string> {  });
        }

        public static Dictionary<string, string> ValidateMorningDishes(List<string> options)
        {
            var dishes = new Dictionary<string, string>();
            
            foreach(var option in options)
            {
                if (option.Trim() == "1")
                {
                    if (dishes.ContainsKey("eggs"))
                    {
                        dishes.Add("error", "10");
                        return dishes;
                    }
                    dishes.Add("eggs", "1");
                }
                if (option.Trim() == "2")
                {
                    if (dishes.ContainsKey("toast"))
                    {
                        dishes.Add("error", "10");
                        return dishes;
                    }
                    dishes.Add("toast", "2");
                }
                if (option.Trim() == "3")
                {
                    if (dishes.ContainsKey("coffee"))
                        continue;

                    dishes.Add($"coffee", "3");
                }
                if (option.Trim() == "4")
                {
                    dishes.Add("error", "4");
                }
            }

            var coffeCounter = options.Where(o => o.Trim() == "3").Count();
            if (coffeCounter > 1)
            {
                var value = dishes["coffee"];
                dishes.Remove("coffee");
                dishes[$"coffee(x{coffeCounter})"] = value;
            }

            return dishes;
        }
    }
}
