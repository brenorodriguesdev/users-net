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

            var Error = Validator_.validate(SignInModel_);

            if (Error != null)
            {
                return BadRequest(Error);
            }

            var InvalidDataError = SignInUseCase_.Sign(SignInModel_);

            if (InvalidDataError != null)
            {
                return Unauthorized(InvalidDataError);
            }

            return Ok();

        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}