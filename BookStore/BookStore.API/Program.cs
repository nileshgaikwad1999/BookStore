using BookStore.API.Configuration;
using BookStore.API.Data;
using BookStore.API.Filter;
using BookStore.API.Middleware;
using BookStore.API.Repository;
using BookStore.API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//option=>option.Filters.Add(new MyFilter())
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var conString = builder.Configuration.GetConnectionString("BookAppDbConnection");
builder.Services.AddDbContext<booksAppContext>(option => option.UseSqlServer(conString));
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddCors(option=>{
    option.AddPolicy("AllowAll", (b) =>
    {
        b.AllowAnyMethod();
        b.AllowAnyHeader();
        b.AllowAnyOrigin();
    });
});
builder.Services.ConfigServiceInitilize();
builder.Services.ConfigRepositoryInitilize();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseRouting();
app.UseAuthorization();

//app.Use(async (ctx, next) =>
//{
//    await next();
//    if (ctx.Response.StatusCode == 404)
//    {
//        Console.WriteLine("404");
//        ctx.Response.Redirect("/api/Authors/Get");
      
//    }

//});
app.GlobleExceptionHandler();
app.UsemyMiddleware();

app.MapControllers();

app.Run();

