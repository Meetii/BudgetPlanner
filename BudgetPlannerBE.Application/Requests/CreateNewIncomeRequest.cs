using BudgetPlannerBE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerBE.Application.Requests
{
    public class CreateNewIncomeRequest
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsPlanned { get; set; }
        public Category? Category { get; set; }
    }
}
