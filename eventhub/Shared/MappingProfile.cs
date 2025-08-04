using AutoMapper;
using Eventhub.WebApp.Data.Entities;
using Eventhub.WebApp.Shared.ViewModel;

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
