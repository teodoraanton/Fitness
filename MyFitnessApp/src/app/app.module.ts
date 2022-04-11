import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon'
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'
import { MatCardModule } from '@angular/material/card';
import { CityService } from './services/city/city.service';
import { GymService } from './services/gym/gym.service';
import { HttpClientModule } from '@angular/common/http';
import { GymDetailsComponent } from './gym-details/gym-details.component';
import { MatTableModule} from '@angular/material/table';
import { GymDescriptionComponent } from './gym-description/gym-description.component';
import { GymDescriptionService } from './services/gym-description/gym-description.service';
import { GymPricesService } from './services/gym-prices/gym-prices.service';
import { GymScheduleService } from './services/gym-schedule/gym-schedule.service';
import { GymTrainersService } from './services/gym-trainers/gym-trainers.service';
import { GymTrainingsService } from './services/gym-trainings/gym-trainings.service';
import { MatGridListModule } from '@angular/material/grid-list';
import { GymPricesComponent } from './gym-prices/gym-prices.component';
import { GymScheduleComponent } from './gym-schedule/gym-schedule.component';
import { GymOpenHoursService } from './services/gym-open-hours/gym-open-hours.service';
import { MatTabsModule } from '@angular/material/tabs';
import { MatListModule } from '@angular/material/list';
import { GymTrainingsComponent } from './gym-trainings/gym-trainings.component';
import { GymTrainersComponent } from './gym-trainers/gym-trainers.component';
import { ReserveNowComponent } from './reserve-now/reserve-now.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDialogModule } from "@angular/material/dialog";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GymDetailsComponent,
    GymDescriptionComponent,
    GymPricesComponent,
    GymScheduleComponent,
    GymTrainingsComponent,
    GymTrainersComponent,
    ReserveNowComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatOptionModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatCardModule,
    HttpClientModule,
    MatTableModule,
    MatGridListModule,
    MatTabsModule,
    MatListModule,
    MatToolbarModule,
    MatDialogModule,
    MatInputModule
  ],
  providers: [
    CityService,
    GymService,
    GymDescriptionService,
    GymPricesService,
    GymOpenHoursService,
    GymScheduleService,
    GymTrainersService,
    GymTrainingsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
