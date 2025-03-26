namespace EventBookingSystem.SessionMethods
{
    public static class SessionExtensions
    {
        public static string GetUserId(this ISession session)
        {
            return session.GetString("UserId") ?? string.Empty;
        }

        public static string GetUserRole(this ISession session)
        {
            return session.GetString("UserRole") ?? string.Empty;
        }

        public static string GetUserName(this ISession session)
        {
            return session.GetString("UserName") ?? string.Empty;
        }

        public static bool IsAdmin(this ISession session)
        {
            return session.GetString("UserRole") == "Admin";
        }

        public static bool IsOrganizer(this ISession session)
        {
            return session.GetString("UserRole") == "Organizer";
        }
    }
}
