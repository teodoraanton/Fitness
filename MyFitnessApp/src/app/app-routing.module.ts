import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GymDetailsComponent } from './gym-details/gym-details.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: "", component: HomeComponent, pathMatch:'full' },
  { path: 'gym-details', component: GymDetailsComponent },
  { path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
