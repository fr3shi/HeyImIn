using System;
using System.ComponentModel.DataAnnotations;

namespace HeyImIn.WebApplication.FrontendModels.ParameterTypes
{
	public class AppointmentFinderInformationDto
	{
		public int EventId { get; set; }

		[Required]
		[MinLength(1)]
		public TimeSlot[] TimeSlots { get; set; }
	}

	public class TimeSlot
	{
		[Required]
		public DateTime FromDate { get; set; }

		[Required]
		public DateTime ToDate { get; set; }
	}
}
