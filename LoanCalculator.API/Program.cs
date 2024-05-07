using System.Text.Json.Serialization;
using LoanCalculator.Application.Factories;
using LoanCalculator.Application.Interfaces;
using LoanCalculator.Application.Services;
using LoanCalculator.Domain.Entities;
using LoanCalculator.Domain.Interfaces;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddXmlSerializerFormatters()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


builder.Services.AddScoped<ILoanApplicationService, LoanApplicationService>();
builder.Services.AddScoped<IPaybackSchemeFactory, PaybackSchemeFactory>();
builder.Services.AddTransient<ILoanFactory, LoanFactory>();
builder.Services.AddTransient<ILoan, HouseLoan>();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var app = builder.Build();

// Global CORS policy
app.UseCors("AllowAll");


// Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();