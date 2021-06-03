using System.Collections.Generic;

public static class SignInValidationFactory
{
    public static Validator make()
    {
        var requiredFields = new List<string>() { "email", "password" };
        var validators = new List<Validator>();

        foreach (string requiredField in requiredFields)
        {
            validators.Add(new RequiredFieldValidator(requiredField));
        }

        validators.Add(new EmailValidator("email"));

        return new CompositeValidator(validators);
    }
}
