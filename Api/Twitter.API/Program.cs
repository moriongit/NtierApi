using Microsoft.EntityFrameworkCore;
using Twitter.DAL.Contexts;
using Twitter.Business;
using Twitter.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Twitter.API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Twitter.Core.Enums;
using Twitter.API.Helpers;

var builder = WebApplication.CreateBuilder(args);
//var jwt = new JWT();
//var config = builder.Configuration.GetSection("Jwt");
var jwt = builder.Configuration.GetSection("Jwt").Get<JWT>();
//config.Bind(jwt);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddDbContext<TwitterContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));
builder.Services.AddUserIdentity();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddBusinessLayer();
builder.Services.AddAuth(jwt);
    
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
    });
}

app.UseHttpsRedirection();
app.UseSeedData();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
