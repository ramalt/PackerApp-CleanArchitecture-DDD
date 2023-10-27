using Microsoft.AspNetCore.Mvc;

namespace PackerApp.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result) 
        => result is not null ? Ok(result) : NotFound();    
}
