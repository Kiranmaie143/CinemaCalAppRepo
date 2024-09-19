using CinemaCalApp.Server.models;
using CinemaCalApp.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CinemaCalApp.Server.Service
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public Task<ActionResult<IEnumerable<Expense>>> GetAllExpensesAsync()
        {
            return _expenseRepository.GetAllExpensesAsync();
        }

        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }
            return await _expenseRepository.AddExpenseAsync(expense);
        }

        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            return await _expenseRepository.GetExpenseByIdAsync(id);
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _expenseRepository.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                throw new KeyNotFoundException("Expense not found");
            }
            await _expenseRepository.DeleteExpenseAsync(expense);
        }
    }
}
