using Microsoft.EntityFrameworkCore;
using Tracker.Configurations;
using Tracker.Data;
using Tracker.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//We read the key from file
var keyPath = builder.Configuration["AES:PATH"];
var aesKey = Misc.ReadFromFile(keyPath);
AESService.ConfigureKey(aesKey);
AppSettings.ConfigureSetting(builder.Configuration);

//Db context injection

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(DatabaseSettings.SectionName));

//var connectionString = builder.Configuration["ConnectionStrings:PRDS"];
var connectionString = AppSettings.GetSettingAsString("ConnectionStrings:PRDS");
builder.Services.AddDbContext<NautinitTrackerContext>(options => options.UseMySQL(connectionString));

var app = builder.Build();

//Adds the settings to the static class


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
