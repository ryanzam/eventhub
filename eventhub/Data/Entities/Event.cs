using Eventhub.WebApp.Features.Events.CreateEvent;
using System.ComponentModel.DataAnnotations;

namespace Eventhub.WebApp.Data.Entities
{
    public class Event
{
        public int EventId { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string? Title { get; set; }
        [StringLength(maximumLength: 300)]
        public string? Description { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public TimeOnly StartTime { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public TimeOnly EndTime { get; set; }

        public string? Category { get; set; } = EventCategoryEnum.Inperson.ToString();
        public string? Venue { get; set; }
    }
}
