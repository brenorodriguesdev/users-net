public interface Crypter
{
    string crypt(string value);
    bool compare(string value, string hashValue);
}