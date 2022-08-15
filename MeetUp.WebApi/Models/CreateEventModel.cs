using AutoMapper;
using MeetUp.Logic.Events.Commands.Create;
using MeetUp.Logic.Mapping;

namespace MeetUp.WebApi.Models
{
    public class CreateEventModel : IMapWith<CreateEventCommand>
    {
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
            profile.CreateMap<CreateEventModel, CreateEventCommand>()
            .ForMember(eventCommand => eventCommand.Title, opt => opt.MapFrom(eventCreate => eventCreate.Title))
            .ForMember(eventCommand => eventCommand.Topic, opt => opt.MapFrom(eventCreate => eventCreate.Topic))
            .ForMember(eventCommand => eventCommand.Description, opt => opt.MapFrom(eventCreate => eventCreate.Description))
            .ForMember(eventCommand => eventCommand.Plan, opt => opt.MapFrom(eventCreate => eventCreate.Plan))
            .ForMember(eventCommand => eventCommand.TimeEvent, opt => opt.MapFrom(eventCreate => eventCreate.TimeEvent))
            .ForMember(eventCommand => eventCommand.Location, opt => opt.MapFrom(eventCreate => eventCreate.Location))
            .ForMember(eventCommand => eventCommand.Organizers, opt => opt.MapFrom(eventCreate => eventCreate.Organizers))
            .ForMember(eventCommand => eventCommand.Speakers, opt => opt.MapFrom(eventCreate => eventCreate.Speakers));
        }
    }
}