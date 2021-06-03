public class Bcrypt : Crypter
{
    public int salt;
    public Bcrypt(int salt)
    {
        this.salt = salt;
    }
    public string crypt(string value)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(this.salt);
        return BCrypt.Net.BCrypt.HashPassword(value, salt);
    }
}