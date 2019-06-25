import { Component } from "@angular/core";
import { TherapyModel } from './therapy.model';
import { TherapyService } from './therapy.service';
import { ClientService } from '../Clients/client.service';
import { TherapistService } from '../Therapists/therapist.service';

import * as moment_ from 'moment';
const moment = moment_;


@Component({
    selector: 'addTherapy',
    templateUrl: './add-therapy.component.html',
})

export class AddTherapyComponent {
    title = "Dodaj terapię";
    public therapy = {} as TherapyModel;
    clients;
    therapists;
    time;

    constructor(public service: TherapyService, public clientService: ClientService, public therapistService: TherapistService) {
        clientService.getAll().subscribe((resp) =>{
            this.clients = resp;
        });

        therapistService.therapistGetAll().subscribe((resp) =>{
            this.therapists = resp;
        });
    }

   
    save = () => {
        this.therapy.Date = this.addTimeToDate();
        this.service.addTherapy(this.therapy).subscribe(
            (resp) => {
                this.therapy.Date = null;
            }
        );
    }

    addTimeToDate = () => {
        var dateString = moment(new Date(this.therapy.Date)).add(this.time.hour,'hours').add(this.time.minute,'minutes').format('DD-MM-YYYY HH:mm:ss');
        var date = moment(dateString, 'DD-MM-YYYY HH:mm:ss').toDate();
        return date;
    }

}
export class NgbdTimepickerBasic {
    time = {hour: 13, minute: 30};
}
  