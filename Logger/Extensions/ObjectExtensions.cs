namespace Logger.Extensions
{
    public static class ObjectExtensions
    {
        public static ILogger GetLogger(this object obj)
        {
            return Logger.GetLogger(obj);
        }
    }
}
