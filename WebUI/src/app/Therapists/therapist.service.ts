import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TherapistModel } from './therapist.model';

@Injectable({
    providedIn: 'root'
  })
  
  
export class TherapistService {
    constructor(private httpClient: HttpClient) {
    }

    public therapistGetAll(){
        return this.httpClient.get('http://localhost:52858/api/Therapist/TherapistGetAll');
    }

    public removeTherapist(therapistId){
        return this.httpClient.delete('http://localhost:52858/api/Therapist/RemoveTherapist/' + therapistId);
    }

    public addTherapist(therapist : TherapistModel){
        return this.httpClient.post('http://localhost:52858/api/Therapist/AddTherapist', therapist);
    }

    public editTherapist(therapistId, therapist : TherapistModel){
        return this.httpClient.put('http://localhost:52858/api/Therapist/EditTherapist/' + therapistId, therapist);
    }

    public getCurrentSchedule(therapistId){
        return this.httpClient.get('http://localhost:52858/api/Therapist/GetCurrentSchedule/' + therapistId);
    }

}