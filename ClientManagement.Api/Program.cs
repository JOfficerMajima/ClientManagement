using ClientManagement.Api.Middleware;
using ClientManagement.Application.Clients;
using ClientManagement.Application.Common;
using ClientManagement.Application.Interfaces;
using ClientManagement.Application.Mapping;
using ClientManagement.Application.Repositories;
using ClientManagement.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClientRepository, PgsqlClientRepository>();

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<TransactionFilter>();
    opt.Filters.Add<ExceptionFilter>();
});

builder.Services.AddAutoMapper(typeof(ClientProfile).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
