using GTF.Presentation.Inputs;

namespace GTF.Presentation.Validators
{
    public class OrderMealValidator
    {
        public static List<string> ValidateOrder(OrderMealRequest request)
        {
            List<string> errors = new();
            if (string.IsNullOrEmpty(request.Input))
            {
                errors.Add("Input is empty.");
                return errors;
            }

            if (!request.Input.Contains(','))
            {
                errors.Add("Input doesn't have any order.");
                return errors;
            }

            var order = request.Input.Split(',');
            var dayTime = order[0];
            if (dayTime.ToLower() != "morning" && dayTime.ToLower() != "night") errors.Add("Day time must be 'morning' or 'night'");
            return errors;
        }
    }
}
