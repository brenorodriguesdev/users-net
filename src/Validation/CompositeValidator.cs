using System.Collections.Generic;

public class CompositeValidator : Validator
{
    private List<Validator> validators;

    public CompositeValidator(List<Validator> validators)
    {
        this.validators = validators;
    }

    public string validate(dynamic data)
    {
        foreach (Validator validator in validators)
        {
            string error = validator.validate(data);
            if (error != null)
            {
                return error;
            }
        }

        return null;
    }
}