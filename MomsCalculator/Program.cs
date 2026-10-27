using MomsCalculator;
using MomsCalculator.service;
using MomsCalculator.Interfaces;
using MomsCalculator.Repo;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITransactionRepo, InMemoryTransactionRepo>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddSingleton<CalculatorService>();
builder.Services.AddScoped<VATReportService>();
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
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
app.UseAntiforgery();

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
