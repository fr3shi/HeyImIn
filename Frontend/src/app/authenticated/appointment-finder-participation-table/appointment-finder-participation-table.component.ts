import {Component, Input} from '@angular/core';
import {TimeSlotDetails} from "../../shared/server-model/timeslot-details.model";
import {compareAsc, format} from "date-fns";
import {MatTableDataSource} from "@angular/material";
import {Accepted} from "../../shared/server-model/appointment-participation-answer.model";

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

  displayedColumns() {
    return ['time'].concat(this.getColumns());
  }
  dataSource: MatTableDataSource<TableElement> | null = null;

  constructor() { }

  getColumns() {
      return Object.keys(this._columnGroups);
  }

  getRows() {
    return this._columnGroups[0];
  }

  getCellsPerColumn(column : string) {
    return this._columnGroups[column]
  }

  private updateColumnGroups() {
    this._columnGroups = {};
    const sortedTimeSlots = this.timeSlots.slice().sort((a, b) => compareAsc(a.fromDate, b.fromDate));

    const rows: { [key: string]: {[key: string]: boolean } } = {};
    for(const timeslot of sortedTimeSlots){
      const date = format(timeslot.fromDate, 'dd.MM.');
      const fromTime = format(timeslot.fromDate, 'HH:mm');
      const toTime = format(timeslot.toDate, 'HH:mm');

      if(this._columnGroups.hasOwnProperty(date)){
        this._columnGroups[date].push(timeslot);
      } else {
        this._columnGroups[date] = [timeslot]
      }

      const time = `${fromTime} - ${toTime}`;

      if (!rows.hasOwnProperty((time))) {
        rows[time] = {};
      }

      rows[time][date] = timeslot.answer === Accepted;
    }

    /* const rows: { [key: string]: boolean[] };

    for(const timeslot of sortedTimeSlots) {
      const fromTime = format(timeslot.fromDate, 'HH:mm');
      const toTime = format(timeslot.toDate, 'HH:mm');

      const time = `${fromTime} - ${toTime}`;
      if (rows.hasOwnProperty(time)) {
        rows[time].push(timeslot.answer === Accepted);
      } else {
        rows[time] = [timeslot.answer === Accepted]
      }
    }*/

    const rowTableElements: TableElement[] = [];
    for(const time of Object.keys(rows)) {
      rowTableElements.push({
        time,
        values: rows[time]
      });
    }

    this.dataSource = new MatTableDataSource<TableElement>(rowTableElements)
  }
}

export interface TableElement {
  time: string;
  values: {
    [key: string]: boolean
  }
}
