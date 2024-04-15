using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Data.SqlClient;
using NetCore8ApiDapper.Helper;
using NetCore8ApiDapper.Interfaces;
using NetCore8ApiDapper.Repository;
using System.Data;
using System.IO.Compression;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*
 KURULMASI GEREKEN NUGETLER
 
 Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.1
 Install-Package Dapper.Contrib -Version 2.0.78
 Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 8.0.1
 Install-Package Newtonsoft.Json -Version 13.0.3
 */

string defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

IDbConnection defaultConnection = new SqlConnection(defaultConnectionString);


string sqlbasarili = "SQL Bağlandı.";
try
{
    using (var connection = new SqlConnection(defaultConnectionString))
    {
        connection.Open();
    }
}
catch (Exception ex)
{
    sqlbasarili = "HATA SQL Bağlanamadı !";
}


string secondConnectionString = builder.Configuration.GetConnectionString("SecondConnection");

IDbConnection secondConnection = new SqlConnection(secondConnectionString);

builder.Services.AddSingleton(new DatabaseConnections(defaultConnection, secondConnection));

builder.Services.AddScoped<IOgrencilerRepository, OgrencilerRepository>();
builder.Services.AddScoped<INotlarRepository, NotlarRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
});

var app = builder.Build();

app.UseResponseCompression();

app.UseCors(builder => builder
.AllowAnyHeader()
.AllowAnyMethod()
.AllowAnyOrigin()
);

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "myapi v1 " + sqlbasarili);
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();// auth i�in
app.UseAuthorization();
app.MapControllers();
app.Run();
