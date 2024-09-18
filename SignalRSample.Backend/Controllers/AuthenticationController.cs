using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SignalRSample.Backend.Dtos;
using SignalRSample.Backend.Entities;

namespace SignalRSample.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(IConfiguration config) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("token")]
    public ActionResult<string> Authenticate([FromBody] AuthenticateDto data)
    {
        if (data == null)
        {
            return Unauthorized();
        }

        if (!Validator(data))
        {
            return Unauthorized();
        }


        var token = GenerateToken(data);

        return Ok(token);
    }

    private string GenerateToken(AuthenticateDto user)
    {
        var securityKey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetValue<string>("Authentication:SecretKey")));

        var signingCridentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new();
        claims.Add(new(JwtRegisteredClaimNames.Name, user.Username));

        var token = new JwtSecurityToken(
            config.GetValue<string>("Authentication:Issuer"),
            config.GetValue<string>("Authentication:Audience"),
            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(30),
            signingCridentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private bool Validator(AuthenticateDto data)
    {
        if (data.Username == "Amir")
        {
            return true;
        }

        return false;
    }
}