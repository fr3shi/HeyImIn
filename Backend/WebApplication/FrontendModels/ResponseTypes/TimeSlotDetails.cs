using HeyImIn.Database.Models;
using System;
using System.Collections.Generic;

namespace HeyImIn.WebApplication.FrontendModels.ResponseTypes
{
	public class TimeSlotDetails
	{
		public TimeSlotDetails(int id, DateTime fromDate, DateTime toDate, AppointmentParticipationAnswer? answer)
		{
			Id = id;
			FromDate = fromDate;
			ToDate = toDate;
			Answer = answer;
		}

		public TimeSlotDetails(int id, DateTime fromDate, DateTime toDate) : this(id, fromDate, toDate, null)
		{
		}

		public int Id { get; set; }
		public DateTime FromDate { get; set; }

		public DateTime ToDate { get; set; }

		public AppointmentParticipationAnswer? Answer { get; set; }
	}
}