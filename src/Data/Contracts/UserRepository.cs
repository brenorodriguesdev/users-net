public interface UserRepository
{
    void save(UserEntity user);
    UserEntity findByEmail(string email);
    UserEntity findById(int idUser);
    void update (UserEntity user);
}