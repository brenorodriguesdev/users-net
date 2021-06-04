using System;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CreateUserController : ControllerBase
{
    private readonly Validator Validator_;
    private readonly CreateUserUseCase CreateUserUseCase_;
    public CreateUserController(Validator Validator_, CreateUserUseCase CreateUserUseCase_)
    {
        this.Validator_ = Validator_;
        this.CreateUserUseCase_ = CreateUserUseCase_;
    }
    [HttpPost]
    public IActionResult Create([FromBody] UserViewModel UserViewModel_)
    {
        try
        {

            var Error = this.Validator_.validate(UserViewModel_);

            if (Error != null)
            {
                return BadRequest(Error);
            }

            var AlreadyExistError = this.CreateUserUseCase_.Create(new UserModel
            {
                name = UserViewModel_.name,
                email = UserViewModel_.email,
                password = UserViewModel_.password
            });

            if (AlreadyExistError != null)
            {
                return BadRequest(AlreadyExistError);
            }

            return Ok();

        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}