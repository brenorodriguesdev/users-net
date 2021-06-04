public class CreateUserService : CreateUserUseCase
{
    private readonly UserRepository UserRepository_;
    private readonly Hasher Hasher_;
    public CreateUserService(UserRepository UserRepository_, Hasher Hasher_)
    {
        this.UserRepository_ = UserRepository_;
        this.Hasher_ = Hasher_;
    }
    public dynamic Create(UserModel User)
    {
        UserEntity AlreadyExistUser = this.UserRepository_.findByEmail(User.email);

        if (AlreadyExistUser != null)
        {
            return "Esse e-mail já está em uso";
        }

        string Password = this.Hasher_.Hash(User.password);

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