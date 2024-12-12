using Microsoft.EntityFrameworkCore;
using TesteConfitec.Data.Context;
using TesteConfitec.Repositories.Interface;
using TesteConfitec.Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string strConn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TesteConfitecContext>(option =>
{
    option.UseSqlServer(strConn);
});


builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    //context.Response.Headers.Add("Access-Control-Allow-Methods: PUT, DELETE", "*");
    await next.Invoke();
});

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
