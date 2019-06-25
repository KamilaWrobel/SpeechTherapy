import { Component, OnInit } from '@angular/core';
import { TherapistService } from '../Therapists/therapist.service';
import { TherapyService } from '../Therapies/therapy.service';
import { MatDialog, MatTableDataSource } from '@angular/material';
import { AddDescriptionPopupComponent } from './add-description-popup.component';
import { TherapyModel } from '../Therapies/therapy.model';

import * as moment_ from 'moment';
import { ShowTherapiesPopupComponent } from './show-therapies-popup.component';
const moment = moment_;


@Component({
    selector: 'schedule',
    templateUrl: './schedule.component.html',
    styleUrls: ['schedule.css'],
})


export class ScheduleComponent implements OnInit {

    currentSchedule = [];
    therapists;
    therapistId;
    therapyToShow = [];
    
    currentWeekDayName =  moment(new Date()).format('dddd');
    

    therapies : TherapyModel[];
    dataSource = new MatTableDataSource(this.currentSchedule);
    data = new MatTableDataSource(this.therapyToShow);

    constructor(public service: TherapistService, public therapyService: TherapyService, public dialog: MatDialog) {
        
        service.therapistGetAll().subscribe((resp) =>{
            this.therapists = resp;
        });
    }

    ngOnInit() {
    }

    getSchedule(therapistId){
        this.service.getCurrentSchedule(therapistId).subscribe((resp: any[]) =>{
            console.log(resp);
            this.currentSchedule = resp;
            //this.dataSource = new MatTableDataSource(this.currentSchedule[0]);
            this.dayOfTheWeek(this.currentWeekDayName);
        })
    }S

    openDialog(therapy: TherapyModel): void {                  
        const dialogRef = this.dialog.open(AddDescriptionPopupComponent, {
          width: '500px',
          data: { element:therapy }
        });
    
        dialogRef.afterClosed().subscribe(result => {

          this.therapyService.changeDescription(therapy.Id, therapy).subscribe();
        });
    }

    dayOfTheWeek(dayOfTheWeek: string){
        console.log("day: " + dayOfTheWeek);
        var found = false;
        for (let index = 0; index < this.currentSchedule.length; index++) {
            const day = this.currentSchedule[index];
            if(dayOfTheWeek === day[0].DayOfTheWeek)
            {
                console.log("day: " + day[0].DayOfTheWeek + " from collection");
                this.dataSource = new MatTableDataSource(this.currentSchedule[index]);
                found = true;
                console.log("found");
            }
        }
        if (!found) {
            console.log("not found");
            this.dataSource = new MatTableDataSource([]);
        }
        
    }

    openDialogShowTherapies(therapy: TherapyModel, clientId, therapistId): void {   
        this.therapyService.therapyToShow(clientId, therapistId).subscribe((resp: any[]) =>{
            const dialogRef = this.dialog.open(ShowTherapiesPopupComponent, {
                width: '500px',
                data: new MatTableDataSource(resp)
              });
        });               
    }

    displayedColumns: string[] = ['hour', 'name', 'description', 'archiwum'];
    
}