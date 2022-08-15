using MeetUp.Data;
using MeetUp.Infrastructure.EntityConfigurations;
using MeetUp.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Infrastructure
{
    public class EventDbContext : DbContext, IEventDbContext
    {
        public DbSet<MeetupEventModel> Events { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
            Console.WriteLine();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
