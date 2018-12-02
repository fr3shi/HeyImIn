import { GeneralEventInformation } from './general-event-information.model';
import { AppointmentDetails } from './appointment-details.model';
import { UserInformation } from './user-information.model';
import { AppointmentFinderDetails} from "./appointment-finder-details.model";

export interface EditEventDetails {
	information: GeneralEventInformation;
	upcomingAppointments: ReadonlyArray<AppointmentDetails>;
  	actualAppointmentFinders: ReadonlyArray<AppointmentFinderDetails>;
	participants: ReadonlyArray<UserInformation>;
}
