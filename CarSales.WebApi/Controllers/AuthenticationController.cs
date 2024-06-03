using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarSales.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    [HttpPost]
    public IActionResult AuthenticateUser(string userName)
    {
        string token = GenerateJwtToken(userName);

        return Ok(new { Token = token });
    }

    private string GenerateJwtToken(string userName)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName),
        };

        var jwtToken = new JwtSecurityToken(
            issuer: "SomeIssuer",
            audience: "SomeAudience",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SOMESECRETKEYULTRASERCRETTOPSECRETKEY")),
                SecurityAlgorithms.HmacSha256Signature));

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}
