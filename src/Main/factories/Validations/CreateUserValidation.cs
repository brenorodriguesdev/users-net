using System.Collections.Generic;

public static class CreateUserValidationFactory
{
    public static Validator make()
    {
        var requiredFields = new List<string>() { "name", "email", "password", "passwordConfirmation" };
        var validators = new List<Validator>();

        foreach (string requiredField in requiredFields)
        {
            validators.Add(new RequiredFieldValidator(requiredField));
        }

        validators.Add(new EmailValidator("email"));

        validators.Add(new CompareFieldValidator("password", "passwordConfirmation"));

        return new CompositeValidator(validators);
    }
}
