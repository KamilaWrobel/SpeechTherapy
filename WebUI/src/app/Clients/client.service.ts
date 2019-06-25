import { ClientModel } from './client.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})


export class ClientService {
    constructor(private httpClient: HttpClient) {
    }

    public addClient(client : ClientModel){
        return this.httpClient.post('http://localhost:52858/api/Client/AddClient', client);
    }

    public getAll(){
        return this.httpClient.get('http://localhost:52858/api/Client/GetAll');
    }

    public getClientStatuses(){
        return this.httpClient.get('http://localhost:52858/api/Client/GetClientStatuses');
    }

    public removeClient(clientId){
        return this.httpClient.delete('http://localhost:52858/api/Client/RemoveClient/' + clientId);
    }
}