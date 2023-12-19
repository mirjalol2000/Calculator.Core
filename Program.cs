using Calculator.Core.Brokers.Storages;
using Calculator.Core.Services.Foundations.Calculations;
using Calculator.Core.Services.Foundations.Feedbacks;
using Calculator.Core.Services.Foundations.Users;
using Calculator.Core.Services.Orchestrations;
using Calculator.Core.Services.Processings.Calculations;
using Calculator.Core.Services.Processings.Feedbacks;
using Calculator.Core.Services.Processings.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IStorageBroker, StorageBroker>();

AddFoundations(builder);
AddProcessings(builder);
Orchestrations(builder);

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

static void AddFoundations(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IUserService, UserService>();
    builder.Services.AddTransient<ICalculationService, CalculationService>();
    builder.Services.AddTransient<IFeedbackService, FeedbackService>();
}

static void AddProcessings(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IUserProcessingService, UserProcessingService>();
    builder.Services.AddTransient<ICalculationProcessingService, CalculationProcessingService>();
    builder.Services.AddTransient<IFeedbackProcessingService, FeedbackProcessingService>();
}

static void Orchestrations(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<ICalculationOrchestrationService, CalculationOrchestrationService>();
}