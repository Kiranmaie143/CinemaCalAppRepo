using CinemaCalApp.Server.models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaCalApp.Server.Repository
{
    public interface IExpenseRepository
    {
        Task<ActionResult<IEnumerable<Expense>>> GetAllExpensesAsync();
        Task<Expense> AddExpenseAsync(Expense expense);
        Task<Expense> GetExpenseByIdAsync(int id);
        Task DeleteExpenseAsync(Expense expense);
    }
}
