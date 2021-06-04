public class Bcrypt : Hasher
{
    public int salt;
    public Bcrypt(int salt)
    {
        this.salt = salt;
    }
    public string Hash(string value)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(this.salt);
        return BCrypt.Net.BCrypt.HashPassword(value, salt);
    }

    public bool Compare(string value, string hashValue)
    {
        return BCrypt.Net.BCrypt.Verify(value, hashValue);
    }
}