using GraphQL.Server;
using TheGarage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GraphQL;
using TheGarage.Repositories;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using TheGarage.Data.Interface;
using TheGarage.Data.Services;
using TheGarage.GraphQL.Types;
using TheGarage.GraphQL.Queries;
using TheGarage.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using GraphQL.Server.Ui.Playground;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CarType = TheGarage.GraphQL.Types.CarType;
using TheGarage.GraphQL.Mutation;
using GraphiQl;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Configuration;
using GraphQL.NewtonsoftJson;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using NuGet.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddControllers();

//builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);


builder.Services.AddDbContext<CarDbContext>(options => options.UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddTransient<CarType>();
builder.Services.AddTransient<CarQuery>();
builder.Services.AddTransient<CarInputType>();
builder.Services.AddTransient<CarRepository>();
builder.Services.AddTransient<RootQuery>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IServiceProvider>(s => new FuncServiceProvider(s.GetRequiredService));
builder.Services.AddTransient<ISchema, RootSchema>();
builder.Services.AddTransient<ISchema, CarSchema>();
builder.Services.AddTransient<CarMutation>();
builder.Services.AddTransient<RootMutation>();

builder.Services.AddGraphQL(b => b
    .AddAutoSchema<Query>()  // schema
    .AddSystemTextJson()); ;

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("*")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowAnyOrigin();
        });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("*")
        .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors(options => {
    options.WithOrigins("http://localhost:3000","http://localhost:3001")
    .AllowAnyHeader()
    .AllowAnyMethod();
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseGraphiQl("/graphql");

app.UseGraphQLPlayground();

app.UseGraphQL<ISchema>();
app.UseGraphQLPlayground();
app.UseWebSockets();

app.Run();

