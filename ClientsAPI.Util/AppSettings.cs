namespace ClientsAPI.Util
{
    public static class AppSettings
    {
        public static string GetConnectionString()
        {
            var configuration = new Configuration();
            return configuration.AppSettings["ConnectionString"];
        }
    }
}