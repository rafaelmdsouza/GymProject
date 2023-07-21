namespace Gym.Infrastructure.Authentication;

public static class Permissions
{
    public static class Policy
    {
        public const string Admin = "Admin";
        public const string Employee = "Employee";
    }

    public static class Role
    {
        public const string Admin = "admin";
        public const string Employee = "employee";
    }
}