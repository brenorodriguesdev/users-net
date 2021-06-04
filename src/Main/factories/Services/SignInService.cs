public static class SignInServiceFactory
{
    public static SignInService make()
    {
        UserRepositoryNpg userRepositoryNpg = new UserRepositoryNpg();
        Bcrypt bcrypt = new Bcrypt(8);
        Jwt jwt = new Jwt("0d734a1dc94fe5a914185f45197ea846");
        return new SignInService(userRepositoryNpg, bcrypt, jwt);
    }
}
