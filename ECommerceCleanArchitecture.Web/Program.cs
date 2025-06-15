using ECommerce.Application.Repositories;
using ECommerce.Application.Services.Order.CreateOrder;
using ECommerce.DataPersistence;
using ECommerce.DataPersistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//add in sql database
builder.Services.RegisterOrdersContext(builder.Configuration);


builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ICreateOrderService, CreateOrderService>();


//add swagger support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
