using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeyImIn.Database.Models
{
	public class TimeSlot
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public virtual AppointmentFinder AppointmentFinder { get; set; }

		[Required]
		[ForeignKey(nameof(AppointmentFinder))]
		public int AppointmentFinderId { get; set; }

		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }

		public virtual ICollection<TimeSlotParticipation> TimeSlotParticipations { get; set; }
	}
}