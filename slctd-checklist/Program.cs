using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using SlctdChecklist.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var cors = "_DevelCORS";

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContextPool<ChecklistDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("GuestbookDbContext"))
    );
    builder.Services.AddCors(options => 
        options.AddPolicy(name: cors,
            policy  =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }
        )
    );
}

var app = builder.Build();

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi.json");
    app.UseCors(cors);
}

app.MapControllers();

app.Run();
