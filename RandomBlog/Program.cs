using Microsoft.AspNetCore.Identity;
using RandomBlog.Application.Extensions;
using RandomBlog.Infrastructure;
using RandomBlog.Infrastructure.Extensions;
using RandomBlog.WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddIdentity<AppIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<RandomBlogDbContext>()
    .AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDefaultFiles();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Web API");
        c.ConfigObject.AdditionalItems.Add("syntaxHighlight", false); //Turns off syntax highlight which causing performance issues...
        c.ConfigObject.AdditionalItems.Add("theme", "agate"); //Reverts Swagger UI 2.x  theme which is simpler not much performance benefit...
    });
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
