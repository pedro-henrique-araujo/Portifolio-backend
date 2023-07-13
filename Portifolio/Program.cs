using Microsoft.EntityFrameworkCore;
using Portifolio.Data;
using Portifolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PortifolioDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Portifolio");
    options.UseSqlite(connectionString);
});
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

using var serviceScope = app.Services.CreateScope();

var dbContext = serviceScope.ServiceProvider.GetService<PortifolioDbContext>();

dbContext?.Database.Migrate();

app.Run();
