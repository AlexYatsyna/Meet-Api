using AutoMapper;
using MeetUp.Logic.Events.Commands.Update;
using MeetUp.Logic.Mapping;

namespace MeetUp.WebApi.Models
{
    public class UpdateEventModel : IMapWith<UpdateEventCommand>
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
            profile.CreateMap<UpdateEventModel, UpdateEventCommand>()
            .ForMember(eventCommand => eventCommand.Id, opt => opt.MapFrom(eventUpdate => eventUpdate.Id))
            .ForMember(eventCommand => eventCommand.Title, opt => opt.MapFrom(eventUpdate => eventUpdate.Title))
            .ForMember(eventCommand => eventCommand.Topic, opt => opt.MapFrom(eventUpdate => eventUpdate.Topic))
            .ForMember(eventCommand => eventCommand.Description, opt => opt.MapFrom(eventUpdate => eventUpdate.Description))
            .ForMember(eventCommand => eventCommand.Plan, opt => opt.MapFrom(eventUpdate => eventUpdate.Plan))
            .ForMember(eventCommand => eventCommand.TimeEvent, opt => opt.MapFrom(eventUpdate => eventUpdate.TimeEvent))
            .ForMember(eventCommand => eventCommand.Location, opt => opt.MapFrom(eventUpdate => eventUpdate.Location))
            .ForMember(eventCommand => eventCommand.Organizers, opt => opt.MapFrom(eventUpdate => eventUpdate.Organizers))
            .ForMember(eventCommand => eventCommand.Speakers, opt => opt.MapFrom(eventUpdate => eventUpdate.Speakers));
        }
    }
}