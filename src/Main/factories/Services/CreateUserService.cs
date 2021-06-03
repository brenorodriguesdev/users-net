using Microsoft.AspNetCore.Mvc;

public static class CreateUserServiceFactory
{
    public static CreateUserService make()
    {
        UserRepositoryNpg userRepositoryNpg = new UserRepositoryNpg();
        Bcrypt bcrypt = new Bcrypt(8);
        return new CreateUserService(userRepositoryNpg, bcrypt);
    }
}
