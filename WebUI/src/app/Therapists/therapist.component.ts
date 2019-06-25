import { Component, OnInit } from "@angular/core";
import {MatTableDataSource} from '@angular/material/table';
import { TherapistModel } from './therapist.model';
import { TherapistService } from './therapist.service';
import { EditTherapistPopupComponent } from './edit-therapist-popup.component';
import { MatDialog } from '@angular/material';



@Component({
    selector: 'therapists',
    styleUrls: ['therapist.css'],
    templateUrl: './therapist.component.html'

})

export class TherapistComponent implements OnInit{

    therapists : TherapistModel[];
    dataSource = new MatTableDataSource(this.therapists);
    
    constructor(public service: TherapistService, public dialog: MatDialog) {   
    }

    ngOnInit() {
        this.loadGridData();
    }
    
    loadGridData(){
        this.service.therapistGetAll().subscribe((resp:TherapistModel[]) =>{
            this.therapists = resp;
            this.dataSource = new MatTableDataSource(this.therapists);
        });
    }


    removeTherapist(therapistId) {
        this.service.removeTherapist(therapistId).subscribe((response => {
            this.loadGridData();
        }));
    }

    openDialog(therapist: TherapistModel): void {
        const dialogRef = this.dialog.open(EditTherapistPopupComponent, {
          width: '250px',
          data: { element:therapist }
        });
    
        dialogRef.afterClosed().subscribe(result => {
          console.log(therapist.Id);

          this.service.editTherapist(therapist.Id, therapist).subscribe();
        

        });
    }


    displayedColumns: string[] = ['Id','Name','removeTherapist', 'editTherapist'];
    

    applyFilter(filterValue: string) {
        this.dataSource.filter = filterValue.trim().toLowerCase();
    }
}