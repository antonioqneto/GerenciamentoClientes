using GerenciamentoClientesApi.Context;
using Microsoft.EntityFrameworkCore;

var politicaCors = "_politicaCors";
var baseUrlApp = "https://localhost:44360/";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("https://localhost:44360");
			//policy.AllowAnyOrigin();
			policy.AllowAnyHeader();
			policy.AllowAnyMethod();
		}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GerenciamentoClientesContext>(options =>
    options.UseSqlite("Data Source=gerenciamentoClientes.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
