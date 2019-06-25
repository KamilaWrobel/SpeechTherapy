import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { TherapistModel } from './therapist.model';



@Component({
  selector: 'edit-therapist',
  templateUrl: './edit-therapist-popup.component.html',
})
export class EditTherapistPopupComponent {

  constructor(
    public dialogRef: MatDialogRef<EditTherapistPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: TherapistModel) {
      console.log(data);
    }

  onNoClick(): void {
    this.dialogRef.close();
  }

}