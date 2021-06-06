using System;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UpdatePasswordController : ControllerBase
{
    private readonly Validator Validator_;
    private readonly UpdatePasswordUseCase UpdatePasswordUseCase_;
    public UpdatePasswordController(Validator Validator_, UpdatePasswordUseCase UpdatePasswordUseCase_)
    {
        this.Validator_ = Validator_;
        this.UpdatePasswordUseCase_ = UpdatePasswordUseCase_;
    }
    [HttpPost]
    public IActionResult Update([FromBody] UpdatePasswordViewModel UpdatePasswordViewModel_)
    {
        try
        {
            var idUser = (int)HttpContext.Items["id"];

            var Error = this.Validator_.validate(UpdatePasswordViewModel_);

            if (Error != null)
            {
                return BadRequest(Error);
            }

            var AlreadyExistError = this.UpdatePasswordUseCase_.update(new UpdatePasswordModel
            {
                idUser = idUser,
                oldPassword = UpdatePasswordViewModel_.oldPassword,
                newPassword = UpdatePasswordViewModel_.newPassword
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