namespace Tracker.Configurations
{
    public class DatabaseSettings
    {
        public const string SectionName = "ConnectionStrings";
        public string PRDS { get; set; } = default!;
    }
}
