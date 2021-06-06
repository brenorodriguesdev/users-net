public class UpdatePasswordService : UpdatePasswordUseCase
{
    private readonly UserRepository UserRepository_;
    private readonly Hasher Hasher_;
    public UpdatePasswordService(UserRepository UserRepository_, Hasher Hasher_)
    {
        this.UserRepository_ = UserRepository_;
        this.Hasher_ = Hasher_;
    }
    public dynamic update(UpdatePasswordModel UpdatePasswordModel)
    {
        UserEntity AlreadyExistUser = this.UserRepository_.findById(UpdatePasswordModel.idUser);

        if (AlreadyExistUser == null)
        {
            return "Esse usuário não existe";
        }
        
        if (!this.Hasher_.Compare(UpdatePasswordModel.oldPassword, AlreadyExistUser.password))
        {
            return "Senha atual incorreta";
        }

        string Password = this.Hasher_.Hash(UpdatePasswordModel.newPassword);

        AlreadyExistUser.password = Password;

        this.UserRepository_.update(AlreadyExistUser);

        return null;
    }
}