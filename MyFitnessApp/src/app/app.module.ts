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
import { MatCardModule } from '@angular/material/card';
import { CityService } from './services/city/city.service';
import { GymService } from './services/gym/gym.service';
import { HttpClientModule } from '@angular/common/http';
import { GymDetailsComponent } from './gym-details/gym-details.component';
import { MatExpansionModule } from '@angular/material/expansion';
import {MatTableModule} from '@angular/material/table';
import { GymDescriptionComponent } from './gym-description/gym-description.component';
import { GymDescriptionService } from './services/gym-description/gym-description.service';
import { GymPricesService } from './services/gym-prices/gym-prices.service';
import { GymScheduleService } from './services/gym-schedule/gym-schedule.service';
import { GymTrainersService } from './services/gym-trainers/gym-trainers.service';
import { GymTrainingsService } from './services/gym-trainings/gym-trainings.service';
import {MatGridListModule} from '@angular/material/grid-list';
import { GymPricesComponent } from './gym-prices/gym-prices.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GymDetailsComponent,
    GymDescriptionComponent,
    GymPricesComponent
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
    MatExpansionModule,
    MatTableModule,
    MatGridListModule
  ],
  providers: [
    CityService,
    GymService,
    GymDescriptionService,
    GymPricesService,
    GymScheduleService,
    GymTrainersService,
    GymTrainingsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
