using Microsoft.EntityFrameworkCore;
using API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

var _secretKey = Environment.GetEnvironmentVariable("SECRET_KEY") ?? throw new ArgumentNullException();

builder.Services.AddAuthentication("Bearer")
.AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = null,
            ValidAudience = null,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey))
        };
    }

);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api1");
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("*")
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();

    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("CohortList"));

builder.Services.AddDbContext<Context>(opt => opt.UseSqlite("Data Source=LocalDatabase.db;Cache=Shared"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();

}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello TO The API!").AllowAnonymous();
app.MapPost("/login", () => "Login Endpoint").AllowAnonymous();

app.MapControllers();
app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("*")
);

app.Run();
