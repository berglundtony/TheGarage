using System;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheGarage.Web.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IGraphQLClient>(t => new GraphQLHttpClient(builder.Configuration["TheGarageApiUri"], new NewtonsoftJsonSerializer()));
builder.Services.AddScoped<CarGraphClient>();
builder.Services.AddHttpClient<CarHttpClient>(o => o.BaseAddress = new Uri(builder.Configuration["TheGarageApiUri"]));
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["TheGarageApiUri"])});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*app.UseHttpsRedirection()*/;
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

