using System.Collections.Generic;

namespace InvestmentFront.Infrastructure.BusinessLogic
{
    public class RangeCalculator : IRangeCalculator
    {
        public IEnumerable<int> GetValues(int min, int max, int step) => CalcValues<int>(min, max, step);

        public IEnumerable<decimal> GetValues(decimal min, decimal max, decimal step) => CalcValues<decimal>(min, max, step);

        private IEnumerable<T> CalcValues<T>(T min, T max, T step)
        {
            var items = new Stack<T>();
            items.Push(min);
            dynamic x = max;
            dynamic y = step;
            for (int i = 0; i < x / y; i++) {
                dynamic t = items.Peek();
                var value = t + y;
                if (value > max) break;
                items.Push(value);
            }
            return items;
        }
    }
}
