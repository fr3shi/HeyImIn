import { NgModule } from '@angular/core';
import {MatCheckboxModule, MatDatepickerModule, MatNativeDateModule, MatSelectModule} from '@angular/material';

// Dialogs
import { AddAppointmentsDialogComponent } from './add-appointments-dialog/add-appointments-dialog.component';
import { AddParticipantDialogComponent } from './add-participant-dialog/add-participant-dialog.component';
import { ChangeOrganizerDialogComponent } from './change-organizer-dialog/change-organizer-dialog.component';

// Profile
import { ProfileComponent } from './profile/profile.component';

// Event components
import { AcceptInviteComponent } from './accept-invite/accept-invite.component';
import { EventsOverviewComponent } from './events-overview/events-overview.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { EditEventComponent } from './edit-event/edit-event.component';
import { ViewEventComponent } from './view-event/view-event.component';
import { EditGeneralEventInfoComponent } from './edit-general-event-details/edit-general-event-info.component';
import { AppointmentParticipantTableComponent } from './appointment-participant-table/appointment-participant-table.component';
import { EditNotificationsComponent } from './edit-notifications/edit-notifications.component';
import { AppointmentParticipationComponent } from './appointment-participation/appointment-participation.component';
import { EventsOverviewListComponent } from './events-overview-list/events-overview-list.component';
import { EventInfoDisplayComponent } from './event-info-display/event-info-display.component';
import { ManageEventParticipantsTableComponent } from './manage-event-participants-table/manage-event-participants-table.component';
import { AppointmentParticipationSummaryComponent } from './appointment-participation-summary/appointment-participation-summary.component';
import { EventChatComponent } from './event-chat/event-chat.component';

// Other
import { AuthenticatedLayoutComponent } from './authenticated-layout/authenticated-layout.component';
import { SharedModule } from '../shared/shared.module';
import { AppointmentFinderParticipationComponent } from './appointment-finder-participation/appointment-finder-participation.component';
import { CreateAppointmentFinderComponent } from './create-appointment-finder/create-appointment-finder.component';
import { CreateAppointmentFinderDialog} from "./create-appointment-finder-dialog/create-appointment-finder-dialog";
import { AppointmentFinderParticipationTableComponent } from './appointment-finder-participation-table/appointment-finder-participation-table.component';

const dialogs = [
	AddAppointmentsDialogComponent,
	AddParticipantDialogComponent,
	ChangeOrganizerDialogComponent,
	CreateAppointmentFinderDialog
];

const components = [
	AuthenticatedLayoutComponent,
	AcceptInviteComponent,
	EventsOverviewComponent,
	ProfileComponent,
	CreateEventComponent,
	EditEventComponent,
	ViewEventComponent,
	EditGeneralEventInfoComponent,
	AppointmentParticipantTableComponent,
	EditNotificationsComponent,
	AppointmentParticipationComponent,
	EventsOverviewListComponent,
	EventInfoDisplayComponent,
	ManageEventParticipantsTableComponent,
	AppointmentParticipationSummaryComponent,
	EventChatComponent
];

@NgModule({
	declarations: [
		...components,
		...dialogs,
		AppointmentFinderParticipationComponent,
		CreateAppointmentFinderComponent,
		AppointmentFinderParticipationTableComponent
	],
	// Dialog contents have to be specified here
	entryComponents: [
		...dialogs
	],
	imports: [
		SharedModule,
		MatSelectModule,
		MatDatepickerModule,
        MatNativeDateModule,
		MatCheckboxModule
	]
})
export class AuthenticatedModule {

}
