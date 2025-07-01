using ECommerce.Application;
using ECommerce.DataPersistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterOrdersContext(builder.Configuration);

builder.Services.RegisterRepositories();

builder.Services.RegisterApplicationServices();


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
