
import { AddClientComponent } from './Clients/add-client.component';
import { ClientsComponent } from './Clients/clients.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule} from '@angular/router';
import { FormsModule, ReactiveFormsModule}from '@angular/forms';
import { MatButtonModule, MatCheckboxModule, MatFormFieldModule, MatTableModule, MatInputModule, MatDatepickerModule, MatNativeDateModule, MatListModule } from '@angular/material';
import { MatDialogModule } from '@angular/material/dialog';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { TherapistComponent } from './Therapists/therapist.component';
import { AddTherapistComponent } from './Therapists/add-therapist.component';
import { TherapistService } from './Therapists/therapist.service';
import { ClientService } from './Clients/client.service';
import { EditTherapistPopupComponent } from './Therapists/edit-therapist-popup.component';
import { AddTherapyComponent } from './Therapies/add-therapy.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { ScheduleComponent } from './Schedule/schedule.component';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { AddDescriptionPopupComponent } from './Schedule/add-description-popup.component';
import { TherapyService } from './Therapies/therapy.service';
import { ShowTherapiesPopupComponent } from './Schedule/show-therapies-popup.component';


@NgModule({
  declarations: [
    AppComponent,
    ClientsComponent,
    AddClientComponent,
    TherapistComponent,
    AddTherapistComponent,
    EditTherapistPopupComponent,
    AddTherapyComponent,
    ScheduleComponent,
    AddDescriptionPopupComponent,
    ShowTherapiesPopupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([
      //{ path:'', component: HomeComponent},
      { path:'clients', component: ClientsComponent},
      { path:'addClient', component: AddClientComponent},
      { path:'therapists', component: TherapistComponent},
      { path:'addTherapist', component: AddTherapistComponent},
      { path:'addTherapy', component: AddTherapyComponent},
      { path:'schedule', component: ScheduleComponent},
    ]),
    FormsModule,
    MatButtonModule, 
    MatCheckboxModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatTableModule,
    MatInputModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    NgbModule,
    MatListModule,
    MatButtonToggleModule
  ],
  exports: [],
  entryComponents: [ EditTherapistPopupComponent, AddDescriptionPopupComponent, ShowTherapiesPopupComponent],
  providers: [ClientService, TherapistService, MatDatepickerModule, TherapyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
