using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerBE.Application.Responses
{
    public class TotalResponse
    {
        public string Month { get; set; }
        public decimal PlannedTotal { get; set; }
        public decimal ActualTotal { get; set; }
    }
}
