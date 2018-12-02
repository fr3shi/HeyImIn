import {TimeSlotDetails} from "./timeslot-details.model";

export interface AppointmentFinderDetails {
  appointmentFinderId: number;
  toDate: Date;
  fromDate: Date;
  timeSlots: ReadonlyArray<TimeSlotDetails>;
}
