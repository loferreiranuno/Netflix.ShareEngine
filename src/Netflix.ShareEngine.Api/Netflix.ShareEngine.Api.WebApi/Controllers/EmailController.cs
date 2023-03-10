using Microsoft.AspNetCore.Mvc;
using Netflix.ShareEngine.Api.Application.Interfaces;

namespace Netflix.ShareEngine.Api.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{ 
    private readonly ILogger<EmailController> _logger;
    private readonly IEmailService _emailService;
    private readonly IGeneratorService _generatorService;

    public EmailController(ILogger<EmailController> logger, IEmailService email, IGeneratorService generator)
    {
        _logger = logger;
        _emailService = email;
        _generatorService = generator;
    } 

    [HttpGet]
    [Route("")]
    public IActionResult Get()
    {
        var canConnect = _emailService.CanConnect();
        var message = canConnect ? "Connected" : "Disconnected";
        return Ok(message);
    }

    [HttpPost]
    [Route("create")]
    public IActionResult Add()
    {
        var username = _generatorService.GenerateUsername(10);
        var password = _generatorService.GeneratePassword(16);        
        _emailService.CreateEmailAccount(username, password);        
        return Ok();
    }
}
