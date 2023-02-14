using Microsoft.AspNetCore.Mvc;
using Netflix.ShareEngine.Api.Application.Interfaces;

namespace Netflix.ShareEngine.Api.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{ 
    private readonly ILogger<EmailController> _logger;
    private readonly IEmailService _service;

    public EmailController(ILogger<EmailController> logger, IEmailService service)
    {
        _logger = logger;
        _service = service;
    } 
}
