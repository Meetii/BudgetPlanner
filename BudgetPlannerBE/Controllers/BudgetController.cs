using BudgetPlannerBE.Application.Interface;
using BudgetPlannerBE.Application.Requests;
using BudgetPlannerBE.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlannerBE.Controllers
{
    [Route("")]
    [ApiController]
    public class BudgetController : Controller
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet("/expenses")]
        public ActionResult GetExpenses()
        {
            var expeneses = this._budgetService.GetAllExpenses();
            return Ok(expeneses);
        }

        [HttpGet("/incomes")]
        public ActionResult GetIncomes()
        {
            var incomes = this._budgetService.GetAllIncome();
            return Ok(incomes);
        }

        [HttpPost("/expenses")]
        public ActionResult<ExpensesResponse> AddExpense(CreateNewExpenseRequest createNewExpenseRequest)
        {
            if(createNewExpenseRequest != null)
            {
                var response = _budgetService.AddExpense(createNewExpenseRequest);
                if (response.Success == true)
                {
                    return Ok();
                }
                else return BadRequest();
            }
            return BadRequest();
        }
        [HttpPost("/incomes")]
        public ActionResult<IncomesResponse> AddIncome(CreateNewIncomeRequest createNewIncomeRequest)
        {
            if (createNewIncomeRequest != null)
            {
                var response = _budgetService.AddIncome(createNewIncomeRequest);
                if (response.Success == true)
                {
                    return Ok();
                }
                else return BadRequest();
            }
            return BadRequest();
        }
        [HttpPost("/register")]
        public ActionResult<CreateUserResponse> CreateUser(CreateNewUserRequest createNewUserRequest)
        {
            if (createNewUserRequest != null)
            {
                var response = _budgetService.CreateNewUser(createNewUserRequest);
                if (response.Success == true)
                {
                    return Ok();
                }
                else return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet("/total")]
        public ActionResult<TotalResponse> CalculateTotal()
        {
            var totalCalculated = this._budgetService.GetAllTotal();
            return Ok(totalCalculated);
        }

    }
}
