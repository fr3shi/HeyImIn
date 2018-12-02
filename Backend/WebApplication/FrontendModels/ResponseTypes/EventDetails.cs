using System.Collections.Generic;

namespace HeyImIn.WebApplication.FrontendModels.ResponseTypes
{
	public class EventDetails
	{
		public EventDetails(ViewEventInformation information, List<AppointmentDetails> upcomingAppointments, List<AppointmentFinderDetails> appointmentFinders, NotificationConfigurationResponse notificationConfigurationResponse)
		{
			Information = information;
			UpcomingAppointments = upcomingAppointments;
			ActualAppointmentFinders = appointmentFinders;
			NotificationConfigurationResponse = notificationConfigurationResponse;
		}

		public ViewEventInformation Information { get; }

		public List<AppointmentDetails> UpcomingAppointments { get; }

		public List<AppointmentFinderDetails> ActualAppointmentFinders { get; set; }

		public NotificationConfigurationResponse NotificationConfigurationResponse { get; }
	}
}
