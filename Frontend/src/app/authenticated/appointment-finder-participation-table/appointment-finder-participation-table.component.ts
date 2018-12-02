import {Component, Input} from '@angular/core';
import {TimeSlotDetails} from "../../shared/server-model/timeslot-details.model";
import {compareAsc, format} from "date-fns";

@Component({
  selector: 'appointment-finder-participation-table',
  templateUrl: './appointment-finder-participation-table.component.html',
  styleUrls: ['./appointment-finder-participation-table.component.scss']
})
export class AppointmentFinderParticipationTableComponent {


  private _timeSlot: ReadonlyArray<TimeSlotDetails>;
  private _columnGroups: { [key: string]: TimeSlotDetails[] };

  get timeSlots(): ReadonlyArray<TimeSlotDetails> {
    return this._timeSlot;
  }
  @Input()
  set timeSlots(val: ReadonlyArray<TimeSlotDetails>)  {
    this._timeSlot = val;
    this.updateColumnGroups();
  }

  constructor() { }

  getColumns() {
      return Object.keys(this._columnGroups);
  }

  getCellsPerColumn(column : string) {
    return this._columnGroups[column]
  }

  private updateColumnGroups() {
    this._columnGroups = {};
    const sortedTimeSlots = this.timeSlots.slice().sort((a, b) => compareAsc(a.fromDate, b.fromDate));

    for(const timeslot of sortedTimeSlots){
      const date = format(timeslot.fromDate, 'dd.MM.yyyy');
      if(this._columnGroups.hasOwnProperty(date)){
        this._columnGroups[date].push(timeslot);
      } else {
        this._columnGroups[date] = [timeslot]
      }
    }
  }
}
