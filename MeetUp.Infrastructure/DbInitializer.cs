namespace MeetUp.Infrastructure
{
    public class DbInitializer
    {
        public static void Initialize(EventDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
