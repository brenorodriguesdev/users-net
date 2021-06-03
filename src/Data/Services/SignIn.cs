public class SignInService : SignInUseCase
{
    private readonly UserRepository UserRepository_;
    private readonly Crypter Crypter_;

    public SignInService(UserRepository UserRepository_, Crypter crypter_)
    {
        this.UserRepository_ = UserRepository_;
        this.Crypter_ = crypter_;
    }
    public dynamic Sign(SignInModel SignInModel)
    {
        UserEntity User = this.UserRepository_.findByEmail(SignInModel.email);

        if (User == null || !this.Crypter_.compare(SignInModel.password, User.password))
        {
            return "Credenciais inválidas";
        }

        return null;
    }
}