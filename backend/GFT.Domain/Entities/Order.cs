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
    }
}
