import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
    selector: 'show-therapies-popup',
    styleUrls: ['showTherapiesPopup.css'],
    templateUrl: './show-therapies-popup.component.html'

})

export class ShowTherapiesPopupComponent {
    constructor(
        public dialogRef: MatDialogRef<ShowTherapiesPopupComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any) {
        }
    
    displayedColumns: string[] = ['Date', 'Description'];
}