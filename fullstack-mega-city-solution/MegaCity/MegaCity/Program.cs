using MegaCity.DbContexts;
using MegaCity.Repositories;
using MegaCity.Services;

const string corsName = "Frontend";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(o => o.AddPolicy(corsName, cors => cors.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BuildingsDbContext>();
builder.Services.AddTransient<IBuildingsRepository, BuildingsRepository>();
builder.Services.AddTransient<IBuildingsService, BuildingsService>();

var app = builder.Build();

using (var context = new BuildingsDbContext()) { context.Database.EnsureCreated(); } // Seed

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(corsName);

app.Run();
