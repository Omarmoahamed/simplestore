using Jsb_Test.BL;
using Jsb_Test.DAL;
using Jsb_Test.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Simplestorecontext>(opts => 
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:dbConnection"]);
    opts.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<Irepository<Order>,OrderRepository>();
builder.Services.AddScoped< Irepository<Product>,productrepository> ();
builder.Services.AddScoped<IrepositoryQuery<Product>, Product_repositoryquery > ();
builder.Services.AddScoped<IrepositoryQuery<Order>,OrderRepository_Query > ();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<Iorderservice, Orderservice>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
