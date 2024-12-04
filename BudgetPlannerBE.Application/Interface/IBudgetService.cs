using BudgetPlannerBE.Application.Requests;
using BudgetPlannerBE.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerBE.Application.Interface
{
    public interface IBudgetService
    {
        CreateUserResponse CreateNewUser(CreateNewUserRequest newUserRequest);

        CustomReponse AddExpense(CreateNewExpenseRequest newExpenseRequest);
        CustomReponse AddIncome(CreateNewIncomeRequest newIncomeRequest);
        ExpensesResponse GetAllExpenses();
        IncomesResponse GetAllIncome();

        List<TotalResponse> GetAllTotal();
        
    }
}
