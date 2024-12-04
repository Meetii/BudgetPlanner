using BudgetPlannerBE.Application.Interface;
using BudgetPlannerBE.Application.Requests;
using BudgetPlannerBE.Application.Responses;
using BudgetPlannerBE.Domain.Models;
using BudgetPlannerBE.Infrastructure.Interface;
using System.Linq;

namespace BudgetPlannerBE.Application.Implementation
{
    public class BudgetService : IBudgetService
    {
        private readonly IRepository<Expense> _expenseRepository;
        private readonly IRepository<Income> _incomeRepository;
        private readonly IRepository<User> _userRepository;

        public BudgetService(IRepository<Expense> expenseRepository, IRepository<Income> incomeRepository, IRepository<User> userRepository)
        {
            _expenseRepository = expenseRepository;
            _incomeRepository = incomeRepository;
            _userRepository = userRepository;
        }


        public CustomReponse AddExpense(CreateNewExpenseRequest newExpenseRequest)
        {
            CustomReponse customReponse = new CustomReponse();
            try
            {
                Expense newExpense = new Expense();
                newExpense.Amount = newExpenseRequest.Amount;
                newExpense.Category = newExpenseRequest.Category;
                newExpense.CategoryId = newExpenseRequest.Category.Id;
                newExpense.IsPlanned = newExpenseRequest.IsPlanned;
                newExpense.Date = newExpenseRequest.Date;
                this._expenseRepository.Insert(newExpense);
                customReponse.Success = true;
                return customReponse;
            }
            catch (Exception _)
            {
                customReponse.Success = false;
                return customReponse;
            }
            
        }

        public CustomReponse AddIncome(CreateNewIncomeRequest newIncomeRequest)
        {
            CustomReponse customReponse = new CustomReponse();
            try
            {
                Income newIncome = new Income();
                newIncome.Amount = newIncomeRequest.Amount;
                newIncome.Category = newIncomeRequest.Category;
                newIncome.CategoryId = newIncomeRequest.Category.Id;
                newIncome.IsPlanned = newIncomeRequest.IsPlanned;
                newIncome.Date = newIncomeRequest.Date;
                this._incomeRepository.Insert(newIncome);
                customReponse.Success = true;
                return customReponse;
            }
            catch (Exception _)
            {
                customReponse.Success = false;
                return customReponse;
            }
        }

        public CreateUserResponse CreateNewUser(CreateNewUserRequest newUserRequest)
        {
            CreateUserResponse customUser = new CreateUserResponse();
            try
            {
                User newUser = new User();
                newUser.UserName = newUserRequest.UserName;
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUserRequest.Password);
                this._userRepository.Insert(newUser);
                customUser.Success = true;
                return customUser;
            }
            catch(Exception _)
            {
                customUser.Success = false;
                return customUser;
            }
        }

        public ExpensesResponse GetAllExpenses()
        {
            ExpensesResponse expensesResponse = new ExpensesResponse();
            try
            {
                expensesResponse.Expenses = this._expenseRepository.GetAll().ToList();
                expensesResponse.Success = true;
                return expensesResponse;
            }
            catch (Exception _)
            {
                expensesResponse.Success = false;
                return expensesResponse;
            }
            
        }

        public IncomesResponse GetAllIncome()
        {
            IncomesResponse incomesResponse = new IncomesResponse();
            try
            {
                incomesResponse.Incomes = this._incomeRepository.GetAll().ToList();
                incomesResponse.Success = true;
                return incomesResponse;
            }
            catch (Exception _)
            {
                incomesResponse.Success = false;
                return incomesResponse;
            }
        }

        public List<TotalResponse> GetAllTotal()
        {
            var incomesReponse = GetAllIncome();
            var expensesReponse = GetAllExpenses();

            if (!incomesReponse.Success || !expensesReponse.Success)
            {
                throw new Exception("Error.");
            }

            var incomes = incomesReponse.Incomes.ToList();
            var expenses = expensesReponse.Expenses.ToList();

            var months = incomes.Select(i => i.Date.Month)
                        .Union(expenses.Select(e => e.Date.Month))
                        .Distinct()
                        .OrderBy(m => m)
                        .ToList();

            var totalList = new List<TotalResponse>();

            foreach (var month in months)
            {
                var monthlyIncomes = incomes.Where(i => i.Date.Month == month).ToList();
                var monthlyExpenses = expenses.Where(e => e.Date.Month == month).ToList();

                var plannedTotal = monthlyIncomes.Where(i => i.IsPlanned).Sum(i => i.Amount)
                    - monthlyExpenses.Where(e => e.IsPlanned).Sum(e => e.Amount);

                var actualTotal = monthlyIncomes.Where(i => !i.IsPlanned).Sum(i => i.Amount)
                    - monthlyExpenses.Where(e => !e.IsPlanned).Sum(e => e.Amount);

                totalList.Add(new TotalResponse
                {
                    Month = new DateTime(1, month, 1).ToString("MMMM"), // Convert month number to name
                    PlannedTotal = plannedTotal,
                    ActualTotal = actualTotal
                });
            }
            
            return totalList;
        }
    }
}
