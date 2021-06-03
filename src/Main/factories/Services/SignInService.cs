public static class SignInServiceFactory
{
    public static SignInService make()
    {
        UserRepositoryNpg userRepositoryNpg = new UserRepositoryNpg();
        Bcrypt bcrypt = new Bcrypt(8);
        return new SignInService(userRepositoryNpg, bcrypt);
    }
}
