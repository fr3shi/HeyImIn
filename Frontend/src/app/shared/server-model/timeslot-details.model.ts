import {TimeSlot} from "./timeslot.model";
import {AppointmentParticipationAnswer} from "./appointment-participation-answer.model";

export interface TimeSlotDetails extends TimeSlot{
	id: number;
	answer?: AppointmentParticipationAnswer;
}
