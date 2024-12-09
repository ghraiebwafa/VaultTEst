using Microsoft.EntityFrameworkCore;
using vaulttest.Data;
using vaulttest.Services;


var builder = WebApplication.CreateBuilder(args);
 builder.Services.AddControllers(); builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<VaultService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }


app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();