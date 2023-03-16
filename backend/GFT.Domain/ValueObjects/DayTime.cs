namespace GFT.Domain.ValueObjects
{
    public class DayTime
    {
        public string Value { get; private set; }
        public DayTime(string value)
        {
            if (value.ToLower() != "morning" && value.ToLower() != "night")
            {
                throw new ArgumentException("The day time can't be different from 'morning' or 'night'");
            }

            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
