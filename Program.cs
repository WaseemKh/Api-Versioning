
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Versioning.Models;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
    options.AssumeDefaultVersionWhenUnspecified = true;

    // hide one of these (QueryString / Header)
    options.ApiVersionReader = new HeaderApiVersionReader("x-API-Version");
    //options.ApiVersionReader = new QueryStringApiVersionReader("hps-api-version");
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'vvv";
    options.SubstituteApiVersionInUrl = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DoccureContext>(options =>
{
    options.UseInMemoryDatabase("Doccure");
});
var app = builder.Build();

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
