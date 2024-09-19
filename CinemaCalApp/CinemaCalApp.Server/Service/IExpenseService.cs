using CinemaCalApp.Server.models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaCalApp.Server.Service
{
    public interface IExpenseService
    {
        Task<ActionResult<IEnumerable<Expense>>> GetAllExpensesAsync();
        Task<Expense> AddExpenseAsync(Expense expense);
        Task<Expense> GetExpenseByIdAsync(int id);
        Task DeleteExpenseAsync(int id);
    }
}
