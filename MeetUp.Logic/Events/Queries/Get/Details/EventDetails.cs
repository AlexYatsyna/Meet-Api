using AutoMapper;
using MeetUp.Data;
using MeetUp.Logic.Mapping;

namespace MeetUp.Logic.Events.Queries.Get
{
    public class EventDetails : IMapWith<MeetupEventModel>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public DateTime TimeEvent { get; set; }
        public string Location { get; set; }
        public string Organizers { get; set; }
        public string Speakers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MeetupEventModel, EventDetails>().ForMember(eventD => eventD.Id, opt => opt.MapFrom(eventO => eventO.Id))
            .ForMember(eventD => eventD.Title, opt => opt.MapFrom(eventO => eventO.Title))
            .ForMember(eventD => eventD.Topic, opt => opt.MapFrom(eventO => eventO.Topic))
            .ForMember(eventD => eventD.Description, opt => opt.MapFrom(eventO => eventO.Description))
            .ForMember(eventD => eventD.Plan, opt => opt.MapFrom(eventO => eventO.Plan))
            .ForMember(eventD => eventD.TimeEvent, opt => opt.MapFrom(eventO => eventO.TimeEvent))
            .ForMember(eventD => eventD.Location, opt => opt.MapFrom(eventO => eventO.Location))
            .ForMember(eventD => eventD.Organizers, opt => opt.MapFrom(eventO => eventO.Organizers))
            .ForMember(eventD => eventD.Speakers, opt => opt.MapFrom(eventO => eventO.Speakers));
        }
    }
}
