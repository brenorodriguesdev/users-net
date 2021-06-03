using System.Text.RegularExpressions;

public class EmailValidator : Validator
{
    private string fieldName;
    static Regex ValidEmailRegex = CreateValidEmailRegex();
    private static Regex CreateValidEmailRegex()
    {
        string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

        return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
    }
    public EmailValidator(string fieldName)
    {
        this.fieldName = fieldName;
    }
    public string validate(dynamic data)
    {
        var email = data?.GetType()?.GetProperty(this.fieldName)?.GetValue(data, null);

        bool isValid = ValidEmailRegex.IsMatch(email);
        
        if (!isValid)
        {
            return fieldName + " não é um campo válido";
        }

        return null;
    }
}