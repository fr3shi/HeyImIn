import {TimeSlot} from "./timeslot.model";

export interface AppointmentFinderInformation {
	toDate: Date;
	fromDate: Date;
	timeSlots: ReadonlyArray<TimeSlot>;
}
