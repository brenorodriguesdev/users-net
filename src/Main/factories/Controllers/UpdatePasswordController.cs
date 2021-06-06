public static class UpdatePasswordControllerFactory
{
    public static UpdatePasswordController make()
    {
        return new UpdatePasswordController(UpdatePasswordValidationFactory.make(), UpdatePasswordServiceFactory.make());
    }
}
