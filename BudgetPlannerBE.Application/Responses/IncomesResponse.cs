using BudgetPlannerBE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerBE.Application.Responses
{
    public class IncomesResponse
    {
        public List<Income> Incomes { get; set; }
        public bool Success { get; set; }
    }
}
