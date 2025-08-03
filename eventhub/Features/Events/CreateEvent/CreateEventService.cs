using Eventhub.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using Eventhub.WebApp.Data.Entities;
using AutoMapper;

namespace Eventhub.WebApp.Features.Events.CreateEvent
{
    public class CreateEventService
    {
        private IDbContextFactory<AppDBContext> dbContextFactory { get; set; }
        private IMapper mapper { get; set; }
        public CreateEventService(IDbContextFactory<AppDBContext> dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public async Task CreateEvent(EventViewModel eventViewModel)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var eventEntity = mapper.Map<Event>(eventViewModel);
                dbContext.Events?.Add(eventEntity);
                await dbContext.SaveChangesAsync();
            }
        }

        public string? ValidateEvent(EventViewModel eventViewModel)
        {
            if(eventViewModel == null)
            {
                return "Event is null";
            }
            string? errorMessage = string.Empty;

            errorMessage = eventViewModel.ValidateEventDates();
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                return errorMessage;
            }

            errorMessage = eventViewModel.ValidateVenue();
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                return errorMessage;
            }

            return string.Empty;
        }
    }
}
