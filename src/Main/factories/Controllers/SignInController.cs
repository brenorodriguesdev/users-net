public static class SignInControllerFactory
{
    public static SignInController make()
    {
        return new SignInController(SignInValidationFactory.make(), SignInServiceFactory.make());
    }
}
