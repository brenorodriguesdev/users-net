public class CreateUserService : CreateUserUseCase
{
    private readonly UserRepository UserRepository_;
    private readonly Crypter Crypter_;
    public CreateUserService(UserRepository UserRepository_, Crypter crypter_)
    {
        this.UserRepository_ = UserRepository_;
        this.Crypter_ = crypter_;
    }
    public void create(UserModel user)
    {
        UserEntity alreadyExistUser = this.UserRepository_.findByEmail(user.email);
        
        if (alreadyExistUser != null)
        {
            return;
        }

        string password = this.Crypter_.crypt(user.password);

        this.UserRepository_.save(new UserEntity
        {
            id = 0,
            name = user.name,
            email = user.email,
            password = password
        });
    }
}