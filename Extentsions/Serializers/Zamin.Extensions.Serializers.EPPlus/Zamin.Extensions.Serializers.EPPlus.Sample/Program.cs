﻿using Zamin.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddZaminParrotTranslator(c =>
{
    c.ConnectionString = "Server =.; Database= StudentManagementDb;User Id = sa;Password=1qaz!QAZ; MultipleActiveResultSets=true";
    c.AutoCreateSqlTable = true;
    c.SchemaName = "dbo";
    c.TableName = "ParrotTranslations";
    c.ReloadDataIntervalInMinuts = 1;
});
builder.Services.AddEPPlusExcelSerializer();
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
