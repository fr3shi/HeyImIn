import {TimeSlot} from "./timeslot.model";

export interface AppointmentFinderInformation {
	timeSlots: ReadonlyArray<TimeSlot>;
}
