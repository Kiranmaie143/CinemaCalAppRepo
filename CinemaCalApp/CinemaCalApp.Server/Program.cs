using CinemaCalApp.Server.middleware;
using CinemaCalApp.Server.models;
using CinemaCalApp.Server.Repository;
using CinemaCalApp.Server.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//connected Db context
builder.Services.AddDbContext<ExpenseContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection")));
// Register the repository using the interface
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

// Register the service using the interface
builder.Services.AddScoped<IExpenseService, ExpenseService>();
// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use the exception handling middleware
app.UseMiddleware<ExceptionMiddleware>();
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
