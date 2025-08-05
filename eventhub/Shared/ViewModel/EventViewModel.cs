using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace Eventhub.WebApp.Shared.ViewModel
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

        public string? Category { get; set; }
        public string? Venue { get; set; }

        public string? EventLink { get; set; }

        public string? ImgUrl { get; set; }

        [Required(ErrorMessage ="Upload an image for the event.")]
        public IBrowserFile CoverImg { get; set; }

        public EventViewModel()
        {
            StartDate = DateOnly.FromDateTime(DateTime.Now);
            StartTime = TimeOnly.FromDateTime(DateTime.Now);
            EndDate = DateOnly.FromDateTime(DateTime.Now);
            EndTime = TimeOnly.FromDateTime(DateTime.Now);
            ImgUrl = $"images/img-placeholder.png";
        }

        public string? ValidateEventDates()
        {
            if(StartDate > EndDate)
            {
                return "Start Date should be earlier than End date.";
            }
            if(StartDate == EndDate && StartTime > EndTime)
            {
                return "Start Time should be earlier than end time";
            }
            return string.Empty;
        }

        public string ValidateVenue()
        {
            if (Category == EventCategoryEnum.Inperson.ToString() && string.IsNullOrWhiteSpace(Venue))
            {
                return "The Venue is required for In-Person event";
            }
            return string.Empty;
        }
    }
}
