import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { BookingComponent } from './booking/booking.component';
import { FormFieldsModule } from 'ngx-form-fields';

@NgModule({
  declarations: [HomeComponent, BookingComponent],
  imports: [SharedModule, HomeRoutingModule, FormFieldsModule],
})
export class HomeModule {}
