using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentFront.Infrastructure.BusinessLogic
{
    public interface IRangeCalculator
    {
        IEnumerable<int> GetValues(int min, int max, int step);
        IEnumerable<decimal> GetValues(decimal min, decimal max, decimal step);
    }
}
