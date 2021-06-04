public class AuthenticationService : AuthenticationUseCase
{
    private readonly UserRepository UserRepository_;
    private readonly Encrypter Encrypter_;
    public AuthenticationService(Encrypter Encrypter_)
    {
        this.Encrypter_ = Encrypter_;
    }

    public dynamic Auth(string AccessToken)
    {
        var data = Encrypter_.Encrypt(AccessToken);
        
        if (data == null)
        {
            return "Esse token de acesso não é válido";
        }

        return data;
    }
}