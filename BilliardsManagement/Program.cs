using BilliardsManagement.Entities;
using BilliardsManagement.Services.implementations;
using BilliardsManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Connect SQL Server
var sqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BilliardsManagementContext>(options => options.UseSqlServer(sqlConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Khai báo đi
builder.Services.AddScoped<IRoleService, RoleService>();

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
