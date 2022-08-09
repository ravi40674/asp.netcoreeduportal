using Microsoft.AspNetCore.Http;

namespace EducationPortal.Helpers
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetObject(key, value);
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            return session.GetObject<T>(key);
        }
    }
}
