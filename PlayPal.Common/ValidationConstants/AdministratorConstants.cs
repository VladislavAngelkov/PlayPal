namespace PlayPal.Common.ValidationConstants
{
    public static class AdministratorConstants
    {
        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 20;

        public const int LastNameMinLength = 2;
        public const int LastNameMaxLength = 30;

        public const string NameErrorMessage = "The {0} must be between {1} and {2} characters long!";
    }
}
