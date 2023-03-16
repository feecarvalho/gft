namespace GFT.Application.Validators
{
    public static class OrderValidator
    {
        public static bool ValidateMorningMeal(string input)
        {
            return true;
        }

        public static List<string> ValidateOrder(string input)
        {
            List<string> errors = new();
            if (input is null) errors.Add("Input is empty.");
            var order = input.Split(',');
            if (order.Length == 1) errors.Add("Input doesn't have any order.");
            var dayTime = order[0];
            if (dayTime.ToLower() != "morning" && dayTime.ToLower() != "night") errors.Add("Day time must be 'morning' or 'night'");

            return errors;
        }
    }
}
