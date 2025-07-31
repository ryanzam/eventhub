using System.ComponentModel.DataAnnotations;

namespace Eventhub.WebApp.Features.Events.CreateEvent
{
    public class EventViewModel
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
        [Required]

        public string? Category { get; set; }
        public string? Venue { get; set; }

        public EventViewModel()
        {
            StartDate = DateOnly.FromDateTime(DateTime.Now);
            StartTime = TimeOnly.FromDateTime(DateTime.Now);
            EndDate = DateOnly.FromDateTime(DateTime.Now);
            EndTime = TimeOnly.FromDateTime(DateTime.Now);
        }

        public bool ValidateEventDates()
        {
            if(StartDate > EndDate)
            {
                return false;
            }
            if(StartDate == EndDate && StartTime > EndTime)
            {
                return false;
            }
            return true;
        }

        public bool ValidateVenue()
        {
            if (Category == EventCategoryEnum.Inperson.ToString() && string.IsNullOrWhiteSpace(Venue))
            {
                return false;
            }
            return true;
        }
    }
}
