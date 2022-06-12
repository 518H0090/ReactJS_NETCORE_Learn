using JWT_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddScoped<IUserRepository,UserRepository>();

//Inject Database
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DevConnection")
    ));

//Add Cors
builder.Services.AddCors(options => options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins(new [] {"http://localhost:3000", "http://localhost:5065" }).AllowAnyHeader().AllowAnyMethod();
        }
    ) );

var app = builder.Build();

//Use Cors
app.UseCors("AllowOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
