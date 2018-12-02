using System.Collections.Generic;

namespace HeyImIn.WebApplication.FrontendModels.ResponseTypes
{
	public class EditEventDetails
	{
		public EditEventDetails(GeneralEventInformation information, List<AppointmentDetails> upcomingAppointments, List<AppointmentFinderDetails> appointmentFinders, List<UserInformation> participants)
		{
			Information = information;
			UpcomingAppointments = upcomingAppointments;
			ActualAppointmentFinders = appointmentFinders;
			Participants = participants;
		}

		public GeneralEventInformation Information { get; }
		public List<AppointmentDetails> UpcomingAppointments { get; }
		public List<AppointmentFinderDetails> ActualAppointmentFinders { get; set; }
		public List<UserInformation> Participants { get; }
	}
}
