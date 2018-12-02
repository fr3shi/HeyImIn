import { ViewEventInformation } from './view-event-information.model';
import { AppointmentDetails } from './appointment-details.model';
import { NotificationConfiguration } from './notification-configuration.model';
import {AppointmentFinderDetails} from "./appointment-finder-details.model";

export interface EventDetails {
	information: ViewEventInformation;
	upcomingAppointments: ReadonlyArray<AppointmentDetails>;
    actualAppointmentFinders : ReadonlyArray<AppointmentFinderDetails>;
	notificationConfigurationResponse: NotificationConfiguration;
}
