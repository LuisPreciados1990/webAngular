import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NgbCalendar, NgbDateStruct, NgbDatepicker } from '@ng-bootstrap/ng-bootstrap';
import es from '@angular/common/locales/es';

import { environment } from '../../../../environments/environment';

import { registerLocaleData, DatePipe } from '@angular/common';
registerLocaleData(es);

@Component({
  selector: 'app-date-picker',
  templateUrl: './date-picker.component.html',
  styleUrls: ['./date-picker.component.css']
})
export class DatePickerComponent implements OnInit {

  env = environment;
  public dp = new DatePipe(navigator.language);
  public format = "yyyy-MM-dd";
  
  public model: NgbDateStruct;
  @ViewChild('dpn') datepicker: NgbDatepicker;

  constructor(public dialogRef: MatDialogRef<DatePickerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private calendar: NgbCalendar) {  
  }

  ngOnInit() {
    let date = new Date(this.env.eFechaSys);
    this.model = { day: date.getUTCDate(), month: date.getUTCMonth() + 1, year: date.getUTCFullYear() };
    this.datepicker.navigateTo({ year: date.getUTCFullYear(), month: date.getUTCMonth() + 1 });
  }
  select() {    
    let myDate = new Date(this.model.year, this.model.month - 1, this.model.day);
    this.env.eFechaSys = this.dp.transform(myDate, this.format);
    this.exit();
  }
  exit(): void {
    this.dialogRef.close();
  }
}
