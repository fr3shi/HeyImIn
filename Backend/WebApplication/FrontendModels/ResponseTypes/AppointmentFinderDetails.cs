using System;
using System.Collections.Generic;

namespace HeyImIn.WebApplication.FrontendModels.ResponseTypes
{
	public class AppointmentFinderDetails
	{
		public AppointmentFinderDetails(
			int appointmentFinderId, 
			List<TimeSlotDetails> timeslots,
			DateTime fromDate,
			DateTime toDate)
		{
			AppointmentFinderId = appointmentFinderId;
			TimeSlots = timeslots;
			FromDate = fromDate;
			ToDate = toDate;
		}

		public int AppointmentFinderId { get; }

		public List<TimeSlotDetails> TimeSlots { get; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
	}
}
