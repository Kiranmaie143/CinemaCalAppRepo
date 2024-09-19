using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaCalApp.Server.models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal PercentageMarkup { get; set; }
        public decimal TotalPrice => Price + (Price * (PercentageMarkup / 100));

    }
}
