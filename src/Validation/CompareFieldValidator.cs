using System;

public class CompareFieldValidator : Validator
{
    private string fieldName;
    private string fieldName2;

    public CompareFieldValidator(string fieldName, string fieldName2)
    {
        this.fieldName = fieldName;
        this.fieldName2 = fieldName2;
    }
    public string validate(dynamic data)
    {

        var valor1 = data?.GetType()?.GetProperty(this.fieldName)?.GetValue(data, null);
        var valor2 = data?.GetType()?.GetProperty(this.fieldName2)?.GetValue(data, null);

        if (valor1 != valor2)
        {
            return this.fieldName + " e " + this.fieldName2 + " não podem ser diferentes";
        }

        return null;
    }
}