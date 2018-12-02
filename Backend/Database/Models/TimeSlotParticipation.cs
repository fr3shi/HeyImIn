using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeyImIn.Database.Models
{
	public class TimeSlotParticipation
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public virtual TimeSlot TimeSlot { get; set; }

		[Required]
		[ForeignKey(nameof(TimeSlot))]
		public int TimeSlotId { get; set; }

		public virtual User Participant { get; set; }

		[Required]
		[ForeignKey(nameof(Participant))]
		public int ParticipantId { get; set; }

		public AppointmentParticipationAnswer? AppointmentParticipationAnswer { get; set; }
	}
}