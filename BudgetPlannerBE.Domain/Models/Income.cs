using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerBE.Domain.Models
{
    public class Income : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsPlanned { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
