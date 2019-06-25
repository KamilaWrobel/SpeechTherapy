import { Component } from "@angular/core";
import { TherapistModel } from './therapist.model';
import { TherapistService } from './therapist.service';

@Component({
    selector: 'add-therapist',
    templateUrl: './add-therapist.component.html',
})

export class AddTherapistComponent {
title = "Dodaj terapeutę";
public therapist = {} as TherapistModel;


    constructor(public service: TherapistService) {
    }
   
    save = () => {
        this.service.addTherapist(this.therapist).subscribe();
    }
}