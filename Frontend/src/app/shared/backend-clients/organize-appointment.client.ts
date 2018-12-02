import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { ServerClientBase } from './server-client-base';
import { AppointmentParticipationAnswer } from '../server-model/appointment-participation-answer.model';
import {AppointmentFinderInformation} from "../server-model/appointment-finder-information.model";

@Injectable({ providedIn: 'root' })
export class OrganizeAppointmentClient extends ServerClientBase {
	constructor(private httpClient: HttpClient) {
		super('OrganizeAppointment');
	}

	public deleteAppointment(appointmentId: number) {
		return this.httpClient.delete<void>(this.baseUrl + '/DeleteAppointment', {
			params: new HttpParams({ fromObject: { appointmentId: appointmentId.toString() } })
		});
	}

	public addAppointments(eventId: number, startTimes: ReadonlyArray<Date | string>) {
		return this.httpClient.post<void>(this.baseUrl + '/AddAppointments', { eventId, startTimes });
	}

    public createAppointmentFinder(eventId: number, appointmentFinderInformation: AppointmentFinderInformation) {
        return this.httpClient.post<void>(this.baseUrl + '/CreateAppointmentFinder', { eventId, ...appointmentFinderInformation });
    }

	public setAppointmentResponse(appointmentId: number, userId: number, response?: AppointmentParticipationAnswer) {
		return this.httpClient.post<void>(this.baseUrl + '/SetAppointmentResponse', { appointmentId, userId, response });
	}
}
