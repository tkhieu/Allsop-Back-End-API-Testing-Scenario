namespace App.Support.Common.Shared
{
    public class AppSettings
    {
        public JWT JWT { get; set; }
    }

    public class JWT
    {
        public string Secret { get; set; }
    }
}