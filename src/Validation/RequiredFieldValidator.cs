using System;

public class RequiredFieldValidator : Validator
{
    private string fieldName;
    public RequiredFieldValidator(string fieldName)
    {
        this.fieldName = fieldName;
    }
    public string validate(dynamic data)
    {

        var valor = data?.GetType()?.GetProperty(this.fieldName)?.GetValue(data, null);

        if (valor == null)
        {
            return this.fieldName + " é um campo obrigatório";
        }

        return null;
    }
}