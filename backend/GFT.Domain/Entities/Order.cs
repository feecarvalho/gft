using GFT.Domain.ValueObjects;

namespace GFT.Domain.Entities
{
    public class Order
    {
        public DayTime DayTime { get; private set; }
        public List<string> Requests { get; private set; }

        public Order(DayTime dayTime, List<string> requests)
        {
            DayTime = dayTime;
            Requests = requests;
        }

        public Order(string input) 
        {
            var order = input.Split(',');
            DayTime = new DayTime(order[0]);
            Requests = new List<string>(order.Skip(1));
        }
    }
}
