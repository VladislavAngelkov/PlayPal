namespace PlayPal.Common.Notifications
{
    public static class ErrorMessages
    {
        public static string InvalidLogin = "Invalid login attempt. Check your email and password!";

        public static string UsedEmail = "This email is already used!";

        public static string ReportDoesNotExist = "Report does not exist!";

        public static string FieldDoesNotExist = "The selected field does not exist!";

        public static string GameDoesNotExist = "The selected game does not exist";

        public static string PositionDoesNotExist = "The selected position does not exist";

        public static string PropertyValueIsNull = "The value of the property is null!";

        public const string FieldIsNotAvalable = "The selected field is not avaliable for the chosen period. Select another field or change the time of the game.";

        public const string EndingTimeBeforeStartingTime = "Ending time should be after the starting time";

        public const string StartingTime = "Starting time cannot be in the past!";

        public const string PlayerIsNotAvailable = "You have already joined in a geme for this period!";
    }
}
