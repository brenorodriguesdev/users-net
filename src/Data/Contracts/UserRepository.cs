public interface UserRepository
{
    void save(UserEntity user);
    UserEntity findByEmail(string email);
}