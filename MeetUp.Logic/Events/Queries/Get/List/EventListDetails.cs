using AutoMapper;
using MeetUp.Data;
using MeetUp.Logic.Mapping;

namespace MeetUp.Logic.Events.Queries.Get.List
{
    public class EventListDetails : IMapWith<MeetupEventModel>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Speakers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MeetupEventModel, EventListDetails>().ForMember(eventD => eventD.Id, opt => opt.MapFrom(eventO => eventO.Id))
            .ForMember(eventD => eventD.Title, opt => opt.MapFrom(eventO => eventO.Title))
            .ForMember(eventD => eventD.Topic, opt => opt.MapFrom(eventO => eventO.Topic))
            .ForMember(eventD => eventD.Speakers, opt => opt.MapFrom(eventO => eventO.Speakers));
        }
    }
}
