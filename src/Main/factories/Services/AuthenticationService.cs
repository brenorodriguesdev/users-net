public static class AuthenticationServiceFactory
{
    public static AuthenticationService make()
    {
        UserRepositoryNpg userRepositoryNpg = new UserRepositoryNpg();
        Jwt jwt = new Jwt("0d734a1dc94fe5a914185f45197ea846");
        return new AuthenticationService(jwt);
    }
}
