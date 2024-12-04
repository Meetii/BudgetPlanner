using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerBE.Domain.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public ICollection<Expense>? Expenses { get; set; }
        public ICollection<Income>? Incomes { get; set; }
    }
}
