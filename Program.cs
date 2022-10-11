using MyTank.Data;
using MyTank.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<TankContext>("Data Source=MyTank.db");

builder.Services.AddScoped<IScopedProcessingService, DefaultScopedProcessingService>();
builder.Services.AddHostedService<ScopedBackgroundService>();

builder.Services.AddScoped<TankService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

app.Run();
