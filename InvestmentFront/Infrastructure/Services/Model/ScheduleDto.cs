using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentFront.Infrastructure.Services.Model
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public double Payment { get; set; }
        public double Body { get; set; }
        public double Percent { get; set; }
        public double Left { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
