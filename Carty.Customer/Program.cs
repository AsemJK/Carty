using Carty.Customer.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});
builder.Services.AddDbContext<CustomerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();