using LaloSuperCars.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;  //probar

var myCorsPolicy = "MyCorsPolicy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ModelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

builder.Services.AddCors(options =>
    {

        options.AddPolicy(myCorsPolicy,
            policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("any-custom-header");
            });


});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(myCorsPolicy);
app.Run();
