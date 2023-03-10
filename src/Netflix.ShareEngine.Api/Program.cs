using Microsoft.Extensions.FileProviders;
using Netflix.ShareEngine.Api.Application.Interfaces;
using Netflix.ShareEngine.Api.Application.Services;
using Netflix.ShareEngine.Domain.Entities.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureAppConfiguration((cb) =>{
    cb.AddEnvironmentVariables();    
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Register Services
builder.Services.AddSingleton<IGeneratorService, GeneratorService>();
builder.Services.AddSingleton<IEmailService>(r => 
{
    var config = r.GetService<IConfiguration>() ?? throw new ConfigurationException("Configuration not loaded");    
    var smtpHost = config.GetValue<string>("SMTP_HOST") ?? throw new ConfigurationException("SMTP_HOST not configured");
    var stmpPort = config.GetValue<int?>("SMTP_PORT") ?? throw new ConfigurationException("SMTP_PORT not configured");
    var smtpUsername = config.GetValue<string>("SMTP_USERNAME") ?? throw new ConfigurationException("SMTP_USERNAME not configured");
    var smtpPassword = config.GetValue<string>("SMTP_PASSWORD") ?? throw new ConfigurationException("SMTP_PASSWORD not configured");
    return new EmailService(smtpHost, stmpPort, smtpUsername, smtpPassword);  
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
