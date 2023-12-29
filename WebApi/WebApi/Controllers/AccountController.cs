using WebApi.Models;
using WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
        // TODO:
        [ApiController] //--------------------------------------------------------------	
        [Route("api/[controller]")] //--------------------------------------------------------------	
        public class AccountController : ControllerBase
        {
            private readonly ITokenService _tokenService;
            public AccountController(ITokenService tokenService)
            {
                _tokenService = tokenService;
            }

            [HttpPost("login")]
            public IActionResult Login(/*TODO:*/[FromBody]/*<-------*/ AuthenticateUser model)
            {
                if (model.Username != "admin" || model.Password != "admin" /*<--------TODO:*/)
                    return Unauthorized("Invalid Credentials");
                else
                    return new JsonResult(new { userName = model.Username, token = _tokenService.CreateToken(model.Username) });
            }
        }
}
