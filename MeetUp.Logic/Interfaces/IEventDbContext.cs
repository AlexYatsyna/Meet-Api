using MeetUp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Logic.Interfaces
{
    public interface IEventDbContext
    {
        DbSet<MeetupEventModel> Events { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
