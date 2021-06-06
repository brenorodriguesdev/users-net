public static class UpdatePasswordServiceFactory
{
    public static UpdatePasswordService make()
    {
        UserRepositoryNpg userRepositoryNpg = new UserRepositoryNpg();
        Bcrypt bcrypt = new Bcrypt(8);
        return new UpdatePasswordService(userRepositoryNpg, bcrypt);
    }
}
