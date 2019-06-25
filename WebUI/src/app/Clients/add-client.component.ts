import { TherapistService } from './../Therapists/therapist.service';
import { Component } from "@angular/core";
import { ClientModel } from './client.model';
import { ClientService } from './client.service';


@Component({
    selector: 'add-client',
    templateUrl: './add-client.component.html',
})

export class AddClientComponent {
title = "Dodaj klienta";
public client = {} as ClientModel;
statusEnum = [];
therapists;

    constructor(public service: ClientService, public therapistService: TherapistService) {
        service.getClientStatuses().subscribe((resp: any[]) =>{
            this.statusEnum = resp;
            console.log(this.statusEnum);
        });

        therapistService.therapistGetAll().subscribe((resp) =>{
            this.therapists = resp;
        });
    }
   
    save = () => {
        this.service.addClient(this.client).subscribe();
    }
}