using Eventhub.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using Eventhub.WebApp.Data.Entities;

namespace Eventhub.WebApp.Features.Events.CreateEvent
{
    public class CreateEventService
    {
        private IDbContextFactory<AppDBContext> dbContextFactory { get; set; }
        public CreateEventService(IDbContextFactory<AppDBContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task CreateEvent(EventViewModel eventViewModel)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var eventEntity = new Event
                {
                    Title = eventViewModel.Title,
                    Description = eventViewModel.Description,
                    StartDate = eventViewModel.StartDate,
                    StartTime = eventViewModel.StartTime,
                    EndDate = eventViewModel.EndDate,
                    EndTime = eventViewModel.EndTime,
                    Category = eventViewModel.Category,
                    Venue = eventViewModel.Venue
                };
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
