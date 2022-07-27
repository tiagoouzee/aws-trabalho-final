using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.Swagger;
using Sample.Serilog.WebApi.Core.Extensions;
using Sample.Serilog.WebApi.Core.Middlewares;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    SerilogExtension.AddSerilogApi(builder.Configuration);
    builder.Host.UseSerilog(Log.Logger);

    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Services.AddControllers();

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {

        app.UseSwagger();
        app.UseSwaggerUI();

    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}
