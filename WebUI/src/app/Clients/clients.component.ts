
import { Component } from "@angular/core";
import {MatTableDataSource} from '@angular/material/table';
import { ClientModel } from './client.model';
import { ClientService } from './client.service';


@Component({
    selector: 'clients',
    styleUrls: ['client.css'],
    templateUrl: './client.component.html'

})

export class ClientsComponent {

    clients : ClientModel[];
    dataSource = new MatTableDataSource(this.clients);
    
    constructor(public service: ClientService) {
        service.getAll().subscribe((resp:ClientModel[]) =>{
            this.clients = resp;
            this.dataSource = new MatTableDataSource(this.clients);
        });
    }

    removeClient(clientId) {
        console.log(clientId);
        this.service.removeClient(clientId).subscribe();
    }

    displayedColumns: string[] = ['Name', 'Age', 'therapist', 'status', 'removeClient'];
    

    applyFilter(filterValue: string) {
        this.dataSource.filter = filterValue.trim().toLowerCase();
    }
}