public static class CreateUserControllerFactory
{
    public static CreateUserController make()
    {
        return new CreateUserController(CreateUserValidationFactory.make(), CreateUserServiceFactory.make());
    }
}
