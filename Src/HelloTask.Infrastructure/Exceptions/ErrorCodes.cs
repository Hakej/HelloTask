namespace HelloTask.Infrastructure.Exceptions
{
    public static class ErrorCodes
    {
        public static string EmailInUse => "email_in_use";
        public static string InvalidEmail => "invalid_email";
        public static string InvalidCredentials => "invalid_credentials";
        public static string UserNotFound => "user_not_found";
        public static string BoardNotFound => "board_not_found";
        public static string TabNotFound => "tab_not_found";
        public static string AssignmentNotFound => "assignment_not_found";
    }
}