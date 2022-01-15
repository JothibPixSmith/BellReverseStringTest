using Bell.Test.Infrastructure.Database;
using Bell.Test.Infrastructure.Repositories;
using Bell.Test.Infrastructure.Repositories.Interfaces;
using Bell.Test.ReverseStringServices;
using Bell.Test.ReverseStringServices.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<ReverseStringContext>($"Data Source=.\\testDb.db");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IReverseStringRepository, ReverseStringRepository>();
builder.Services.AddTransient<IReverseStringService, ReverseStringService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
