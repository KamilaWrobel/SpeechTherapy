import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { TherapyModel } from '../Therapies/therapy.model';



@Component({
  selector: 'add-description',
  templateUrl: './add-description-popup.component.html',
})
export class AddDescriptionPopupComponent {

  constructor(
    public dialogRef: MatDialogRef<AddDescriptionPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: TherapyModel) {
      console.log(data);
    }

  onNoClick(): void {
    this.dialogRef.close();
  }

}