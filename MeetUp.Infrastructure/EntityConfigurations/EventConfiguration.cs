using MeetUp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Infrastructure.EntityConfigurations
{
    internal class EventConfiguration : IEntityTypeConfiguration<MeetupEventModel>
    {
        public void Configure(EntityTypeBuilder<MeetupEventModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
