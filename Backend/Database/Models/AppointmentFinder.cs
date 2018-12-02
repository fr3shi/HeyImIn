using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeyImIn.Database.Models
{
	public class AppointmentFinder
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public virtual Event Event { get; set; }

		[Required]
		[ForeignKey(nameof(Event))]
		public int EventId { get; set; }

		[Required]
		public DateTime FromDate { get; set; }
		[Required]
		public DateTime ToDate { get; set; }

		public virtual ICollection<TimeSlot> TimeSlots { get; set; }
	}
}