namespace PlayPal.Common.ValidationConstants
{
    public static class FieldOwnerConstants
    {
        public const int ContactAddressMinLength = 10;
        public const int ContactAddressMaxLength = 100;

        public const int CompanyNameMinLength = 5;
        public const int CompanyNameMaxLength = 100;

        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 20;

        public const int LastNameMinLength = 2;
        public const int LastNameMaxLength = 30;

        public const string NameErrorMessage = "The {0} must be between {1} and {2} characters long!";

        public const string AddressErrorMessage = "The address must be between {1} and {2} characters long!";

        public const string CompanyNameErrorMessage = "The name of the company must be between {1} and {2} characters long";
    }
}
