using Microsoft.EntityFrameworkCore;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Repository;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Repositories and services
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITokenService, TokenService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//connection string 
builder.Services.AddDbContext<LibraryContext>(equals => equals.UseSqlServer(builder.Configuration.GetConnectionString("LIMS")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
