import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TherapyModel } from './therapy.model';

@Injectable({
    providedIn: 'root'
  })
  
  
export class TherapyService {
    constructor(private httpClient: HttpClient) {
    }

    public getAll(){
        return this.httpClient.get('http://localhost:52858/api/Therapy/GetAll');
    }

    public addTherapy(therapy : TherapyModel){
        return this.httpClient.post('http://localhost:52858/api/Therapy/AddTherapy', therapy);
    }

    public changeDescription(therapyId, therapy: TherapyModel){
        return this.httpClient.put('http://localhost:52858/api/Therapy/ChangeDescription/' + therapyId, therapy);
    }

    public therapyToShow(clientId, therapistId){
        return this.httpClient.get('http://localhost:52858/api/Therapy/TherapyToShow/' + clientId + '/' + therapistId);
    }
}