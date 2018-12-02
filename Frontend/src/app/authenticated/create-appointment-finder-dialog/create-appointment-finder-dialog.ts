import { Component, ChangeDetectionStrategy } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import {addDays, eachDayOfInterval, parse} from 'date-fns';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AppointmentFinderInformation} from "../../shared/server-model/appointment-finder-information.model";
import {TimeSlot} from "../../shared/server-model/timeslot.model";

@Component({
	styleUrls: ['./create-appointment-finder-dialog.scss'],
	templateUrl: './create-appointment-finder-dialog.html',
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class CreateAppointmentFinderDialog {
	public form: FormGroup;

	private readonly timePattern = '\\d{2}:\\d{2}';

	constructor(private dialogRef: MatDialogRef<CreateAppointmentFinderDialog, AppointmentFinderInformation>, fb: FormBuilder) {
		this.form = fb.group({
			fromDateCtrl: [new Date(), [Validators.required]],
            toDateCtrl: [addDays(new Date(), 1), [Validators.required]],
            fromTimeCtrl: ['18:00', [Validators.required, Validators.pattern(this.timePattern)]],
            toTimeCtrl: ['22:00', [Validators.required, Validators.pattern(this.timePattern)]]
		});
	}

	public parseAndReturnFinder() {
        const fromDate: Date = this.form.value.fromDateCtrl;
        const toDate: Date = this.form.value.toDateCtrl;
        const fromTime: string = this.form.value.fromTimeCtrl;
        const toTime: string = this.form.value.toTimeCtrl;

        const timeSlots: TimeSlot[] = [];

        for (const date of eachDayOfInterval({start: fromDate, end: toDate})) {
            timeSlots.push({
				fromDate: parse(fromTime, 'HH:mm', date),
				toDate:  parse(toTime, 'HH:mm', date)
            });
        }

		this.dialogRef.close({
		  timeSlots:	timeSlots,
          toDate: toDate,
          fromDate: fromDate
		});
	}
}
