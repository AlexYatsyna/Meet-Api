using MeetUp.Data;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Logic.Interfaces
{
    public interface IEventDbContext
    {
        DbSet<MeetupEventModel> Events { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
