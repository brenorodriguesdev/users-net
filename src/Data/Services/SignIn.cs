using System;

public class SignInService : SignInUseCase
{
    private readonly UserRepository UserRepository_;
    private readonly Hasher Hasher_;
    private readonly Crypter Crypter_;

    public SignInService(UserRepository UserRepository_, Hasher Hasher_, Crypter Crypter_)
    {
        this.UserRepository_ = UserRepository_;
        this.Hasher_ = Hasher_;
        this.Crypter_ = Crypter_;
    }
    public dynamic Sign(SignInModel SignInModel)
    {
        UserEntity User = this.UserRepository_.findByEmail(SignInModel.email);

        if (User == null || !this.Hasher_.Compare(SignInModel.password, User.password))
        {
            return "Credenciais inválidas";
        }

        string accessToken = this.Crypter_.Crypt(User.id);

        return accessToken;
    }
}