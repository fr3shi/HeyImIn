using System;
using System.Collections.Generic;

namespace HeyImIn.WebApplication.FrontendModels.ResponseTypes
{
	public class AppointmentFinderDetails
	{
		public AppointmentFinderDetails(int appointmentFinderId, List<TimeSlotDetails> timeslots)
		{
			AppointmentFinderId = appointmentFinderId;
			TimeSlots = timeslots;
		}

		public int AppointmentFinderId { get; }

		public List<TimeSlotDetails> TimeSlots { get; }
	}
}
