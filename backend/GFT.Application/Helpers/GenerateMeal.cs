using GFT.Domain.Entities;

namespace GFT.Application.Validators
{
    public static class GenerateMeal
    {
        public static Dictionary<int, string> GenerateDishes(Order order)
        {
            if (order.DayTime.Value.ToLower() == "morning")
            {
                return GenerateMorningDishes(order.Requests);
            }

            return GenerateNightDishes(order.Requests);
        }

        private static Dictionary<int, string> GenerateMorningDishes(List<string> options)
        {
            var dishes = new Dictionary<int, string>();

            foreach (var option in options)
            {
                if (dishes.ContainsKey(4)) return dishes;

                switch (option.Trim())
                {
                    case "1":
                        AddDish(dishes, 1, "eggs");
                        break;

                    case "2":
                        AddDish(dishes, 2, "toast");
                        break;

                    case "3":
                        AddDish(dishes, 3, "coffee", true);
                        break;

                    case "4":
                        AddDish(dishes, 4, "error");
                        break;

                    default:
                        AddDish(dishes, 4, "error");
                        break;
                }
            }
            FixDuplications(dishes, options, "3", "coffe");
            return dishes;
        }
        private static Dictionary<int, string> GenerateNightDishes(List<string> options)
        {
            var dishes = new Dictionary<int, string>();

            foreach (var option in options)
            {
                if (dishes.ContainsKey(5)) return dishes;

                switch (option.Trim())
                {
                    case "1":
                        AddDish(dishes, 1, "steak");
                        break;

                    case "2":
                        AddDish(dishes, 2, "potato", true);
                        break;

                    case "3":
                        AddDish(dishes, 3, "wine");
                        break;

                    case "4":
                        AddDish(dishes, 4, "cake");
                        break;

                    default:
                        AddDish(dishes, 5, "error");
                        break;
                }
            }
            FixDuplications(dishes, options, "2", "potato");
            return dishes;
        }

        private static void AddDish(Dictionary<int, string> dishes, int key, string value, bool multipleOrdersAllowed = false)
        {
            if (multipleOrdersAllowed && dishes.ContainsKey(key)) return;

            if (dishes.ContainsKey(key))
            {
                dishes[5] = "error";
                return;
            }
            dishes.Add(key, value);
            return;
        }

        private static void FixDuplications(Dictionary<int, string> dishes, List<string> options, string key, string dish)
        {
            int counter = options.Count(d => d == key);
            if (counter > 1)
            {
                dishes.Remove(Convert.ToInt32(key));
                dishes.Add(Convert.ToInt32(key), $"{dish}(x{counter})");
            }
        }
    }
}
