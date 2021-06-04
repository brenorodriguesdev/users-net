using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

public class Jwt : Crypter
{
    private readonly string SecretKey;
    public Jwt(string SecretKey)
    {
        this.SecretKey = SecretKey;
    }
    public string Crypt(dynamic value)
    {
        var symmetricKey = Convert.FromBase64String(this.SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var now = DateTime.UtcNow;
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, Convert.ToString(value))
        }),

            Expires = now.AddHours(1),

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(symmetricKey),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var stoken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(stoken);

        return token;
    }

}