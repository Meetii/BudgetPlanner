using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerBE.Domain.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Expense>? Expenses { get; set; }
        public ICollection<Income>? Incomes { get; set; }

    }
}
