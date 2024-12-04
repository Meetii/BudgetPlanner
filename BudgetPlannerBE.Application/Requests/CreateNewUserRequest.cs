using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerBE.Application.Requests
{
    public class CreateNewUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
