namespace PlayPal.Common.ValidationConstants
{
    public static class PlayerConstants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 40;

        public const int CitiMinLength = 3;
        public const int CitiMaxLength = 30;

        public const string NameErrorMessage = "The {0} must be between {1} and {2} characters long";

        public const string CityErrorMessage = "The {0} must be between {1} and {2} characters long";
    }
}
