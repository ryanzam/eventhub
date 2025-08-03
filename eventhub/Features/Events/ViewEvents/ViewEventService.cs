using AutoMapper;
using Eventhub.WebApp.Data;
using Eventhub.WebApp.Data.Entities;
using Eventhub.WebApp.Features.Events.CreateEvent;
using Microsoft.EntityFrameworkCore;

namespace Eventhub.WebApp.Features.Events.ViewEvents
{
    public class ViewEventService
    {
        private readonly IDbContextFactory<AppDBContext> dbContextFactory;
        private readonly IMapper mapper;
        public ViewEventService(IDbContextFactory<AppDBContext> dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public async Task<List<EventViewModel>> GetEventsAsync()
        {
            using var dbContext = await dbContextFactory.CreateDbContextAsync();
            var events =  await (dbContext.Events?.ToListAsync() ?? Task.FromResult(new List<Event>()));

            return mapper.Map<List<EventViewModel>>(events);
        }
    }
}
