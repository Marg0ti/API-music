using HernandezMargot_API_M.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions( x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //evitar referencias circulares

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ChinookModificadaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Chinook-connection")));



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
