using System;
using Npgsql;

public class UserRepositoryNpg : UserRepository
{

    private static string Host = "127.0.0.1";
    private static string User = "postgres";
    private static string DBname = "net";
    private static string Password = "1";
    private static string Port = "5432";

    public void save(UserEntity user)
    {

        string connString =
              String.Format(
                  "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                  Host,
                  User,
                  DBname,
                  Port,
                  Password);


        using (var conn = new NpgsqlConnection(connString))

        {
            conn.Open();

            using (var command = new NpgsqlCommand("insert into user_account (email, name, password) values (@email,@name,@password)", conn))
            {
                command.Parameters.AddWithValue("email", user.email);
                command.Parameters.AddWithValue("name", user.name);
                command.Parameters.AddWithValue("password", user.password);
                command.ExecuteNonQuery();
            }

            conn.Close();
        }

    }


    public void update(UserEntity user)
    {

        string connString =
              String.Format(
                  "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                  Host,
                  User,
                  DBname,
                  Port,
                  Password);


        using (var conn = new NpgsqlConnection(connString))

        {
            conn.Open();

            using (var command = new NpgsqlCommand("update user_account set email = @email, name = @name, password = @password where id = @id", conn))
            {
                command.Parameters.AddWithValue("email", user.email);
                command.Parameters.AddWithValue("name", user.name);
                command.Parameters.AddWithValue("password", user.password);
                command.Parameters.AddWithValue("id", user.id);
                command.ExecuteNonQuery();
            }

            conn.Close();
        }

    }

    public UserEntity findByEmail(string email)
    {

        UserEntity user = null;

        string connString =
              String.Format(
                  "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                  Host,
                  User,
                  DBname,
                  Port,
                  Password);


        using (var conn = new NpgsqlConnection(connString))

        {
            conn.Open();

            using (var command = new NpgsqlCommand("select * from user_account where email = @email", conn))
            {
                command.Parameters.AddWithValue("email", email);
                NpgsqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    user = new UserEntity();

                    user.id = Convert.ToInt32(reader["id"]);
                    user.name = Convert.ToString(reader["name"]);
                    user.email = Convert.ToString(reader["email"]);
                    user.password = Convert.ToString(reader["password"]);

                }
            }

            conn.Close();
        }

        return user;
    }

    public UserEntity findById(int idUser)
    {

        UserEntity user = null;

        string connString =
              String.Format(
                  "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                  Host,
                  User,
                  DBname,
                  Port,
                  Password);


        using (var conn = new NpgsqlConnection(connString))

        {
            conn.Open();

            using (var command = new NpgsqlCommand("select * from user_account where id = @id", conn))
            {
                command.Parameters.AddWithValue("id", idUser);
                NpgsqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    user = new UserEntity();

                    user.id = Convert.ToInt32(reader["id"]);
                    user.name = Convert.ToString(reader["name"]);
                    user.email = Convert.ToString(reader["email"]);
                    user.password = Convert.ToString(reader["password"]);

                }
            }

            conn.Close();
        }

        return user;
    }

}