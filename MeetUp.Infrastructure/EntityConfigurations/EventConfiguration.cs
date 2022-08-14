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
            builder.HasKey(ev => ev.Id);
            builder.HasIndex(ev => ev.Id).IsUnique();
            builder.Property(ev => ev.Topic).IsRequired().HasMaxLength(25);
            builder.Property(ev => ev.Title).IsRequired().HasMaxLength(30);
            builder.Property(ev => ev.Description).IsRequired().HasMaxLength(255);
            builder.Property(ev => ev.Plan).IsRequired().HasMaxLength(255);
            builder.Property(ev => ev.Location).IsRequired().HasMaxLength(50);
            builder.Property(ev => ev.TimeEvent).IsRequired();
            builder.Property(ev => ev.Speakers).IsRequired().HasMaxLength(255);
            builder.Property(ev => ev.Organizers).IsRequired().HasMaxLength(255);
        }
    }
}
