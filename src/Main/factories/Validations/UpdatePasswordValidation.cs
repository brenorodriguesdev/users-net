using System.Collections.Generic;

public static class UpdatePasswordValidationFactory
{
    public static Validator make()
    {
        var requiredFields = new List<string>() { "oldPassword", "newPassword", "newPasswordConfirmation" };
        var validators = new List<Validator>();

        foreach (string requiredField in requiredFields)
        {
            validators.Add(new RequiredFieldValidator(requiredField));
        }

        validators.Add(new CompareFieldValidator("newPassword", "newPasswordConfirmation"));

        return new CompositeValidator(validators);
    }
}
