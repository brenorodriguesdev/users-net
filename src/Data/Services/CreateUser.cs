public class CreateUserService : CreateUserUseCase
{
    private readonly UserRepository UserRepository_;
    private readonly Crypter Crypter_;
    public CreateUserService(UserRepository UserRepository_, Crypter crypter_)
    {
        this.UserRepository_ = UserRepository_;
        this.Crypter_ = crypter_;
    }
    public dynamic Create(UserModel User)
    {
        UserEntity AlreadyExistUser = this.UserRepository_.findByEmail(User.email);

        if (AlreadyExistUser != null)
        {
            return "Esse e-mail já está em uso";
        }

        string Password = this.Crypter_.crypt(User.password);

        this.UserRepository_.save(new UserEntity
        {
            id = 0,
            name = User.name,
            email = User.email,
            password = Password
        });

        return null;
    }
}