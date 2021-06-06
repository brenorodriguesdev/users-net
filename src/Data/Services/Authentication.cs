public class AuthenticationService : AuthenticationUseCase
{
    private readonly Encrypter Encrypter_;
    public AuthenticationService(Encrypter Encrypter_)
    {
        this.Encrypter_ = Encrypter_;
    }

    public dynamic Auth(string AccessToken)
    {
        var Data = this.Encrypter_.Encrypt(AccessToken);

        if (Data == null)
        {
            return "Esse token de acesso não é válido";
        }

        return Data;
    }
}