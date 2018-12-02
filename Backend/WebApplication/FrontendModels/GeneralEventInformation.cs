using System.ComponentModel.DataAnnotations;
using HeyImIn.Database.Models;

namespace HeyImIn.WebApplication.FrontendModels
{
	public class GeneralEventInformation
	{
		public GeneralEventInformation()
		{
			
		}

		public GeneralEventInformation(string title, string meetingPlace, string description, bool isPrivate, bool doFindTime, int reminderTimeWindowInHours, int summaryTimeWindowInHours)
		{
			Title = title;
			MeetingPlace = meetingPlace;
			Description = description;
			IsPrivate = isPrivate;
            DoFindTime = doFindTime;
			ReminderTimeWindowInHours = reminderTimeWindowInHours;
			SummaryTimeWindowInHours = summaryTimeWindowInHours;
		}

		[Required]
		[MaxLength(FieldLengths.TitleMaxLength)]
		public string Title { get; set; }

		[Required]
		[MaxLength(FieldLengths.MeetingPlaceMaxLength)]
		public string MeetingPlace { get; set; }

		[Required]
		[MaxLength(FieldLengths.DescriptionMaxLength)]
		public string Description { get; set; }

		public bool IsPrivate { get; set; }

        public bool DoFindTime { get; set; }

        [Range(0, FieldLengths.RealisticMaximumHours)]
		public int ReminderTimeWindowInHours { get; set; }

		[Range(0, FieldLengths.RealisticMaximumHours)]
		public int SummaryTimeWindowInHours { get; set; }
	}
}
