using System;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SignInController : ControllerBase
{
    private readonly Validator Validator_;
    private readonly SignInUseCase SignInUseCase_;
    public SignInController(Validator Validator_, SignInUseCase SignInUseCase_)
    {
        this.Validator_ = Validator_;
        this.SignInUseCase_ = SignInUseCase_;
    }
    [HttpPost]
    public IActionResult Sign([FromBody] SignInModel SignInModel_)
    {
        try
        {

            var Error = this.Validator_.validate(SignInModel_);

            if (Error != null)
            {
                return BadRequest(Error);
            }

            var AccessToken = this.SignInUseCase_.Sign(SignInModel_);

            if (AccessToken == "Credenciais inválidas")
            {
                return Unauthorized(AccessToken);
            }

            return Ok(AccessToken);

        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}