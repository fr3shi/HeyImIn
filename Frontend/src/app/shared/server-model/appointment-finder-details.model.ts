import {TimeSlotDetails} from "./timeslot-details.model";

export interface AppointmentFinderDetails {
	appointmentFinderId: number;
    timeSlots: ReadonlyArray<TimeSlotDetails>;
}
