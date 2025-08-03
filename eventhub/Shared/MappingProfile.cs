using AutoMapper;
using Eventhub.WebApp.Data.Entities;
using Eventhub.WebApp.Features.Events.CreateEvent;

namespace Eventhub.WebApp.Shared
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<EventViewModel, Event>();
            CreateMap<Event, EventViewModel>();
        }
    }
}
