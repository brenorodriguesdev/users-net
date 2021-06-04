public interface Hasher
{
    string Hash(string value);
    bool Compare(string value, string hashValue);
}