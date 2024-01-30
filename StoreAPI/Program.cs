using Microsoft.EntityFrameworkCore;
using StoreAPI.Domain.Interfaces.Repositories;
using StoreAPI.Infrastructure.DataBase;
using StoreAPI.Infrastructure.UnitOfWork.Repositories;
using StoreAPI.Service.Interfaces;
using StoreAPI.Service.Business;
using AutoMapper;
using FluentValidation.AspNetCore;
using StoreAPI.Domain.Validators;
using StoreAPI.Utilities;
using FluentValidation;
using System;
using StoreAPI.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);
var databaseConnection = builder.Configuration.GetConnectionString("DbConnection");

// Add services to the container.
builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(databaseConnection, b => b.MigrationsAssembly("StoreAPI")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProdcutService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddControllers();
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
