using ECommerce.Application;
using ECommerce.DataPersistence;
using ECommerce.Infrastructure;
using ECommerceCleanArchitecture.Web.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterDomainService();

builder.Services.RegisterApplicationServices();

builder.Services.RegisterOrdersContext(builder.Configuration);

builder.Services.RegisterRepositories();

builder.Services.RegisterInfrastructure();

//add swagger support
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
