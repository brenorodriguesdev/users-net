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

            var error = Validator_.validate(UserViewModel_);

            if (error != null)
            {
                return BadRequest(error);
            }

            var errorAlreadyExist = CreateUserUseCase_.create(new UserModel
            {
                name = UserViewModel_.name,
                email = UserViewModel_.email,
                password = UserViewModel_.password
            });

            if (errorAlreadyExist != null)
            {
                return BadRequest(errorAlreadyExist);
            }

            return null;

        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}