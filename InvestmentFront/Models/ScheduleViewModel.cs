using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestmentFront.Models
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double Payment { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double Body { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double Percent { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}")]
        public double Left { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
