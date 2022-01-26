using BookStoreWebAPI.Data;
using BookStoreWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//registering services
builder.Services.AddTransient<IBookRepository, BookRepository>();
//registering DBContext
builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDB")));

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
