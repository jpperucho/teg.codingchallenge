import { NgModule } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbCarouselModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { VenuesComponent } from './components/venues/venues.component';
import { FormsModule } from '@angular/forms';
import { EventsComponent } from './components/events/events.component';
import { DatePipe } from '@angular/common';
import { VenueService } from './services/venue.service';
import { EventService } from './services/event.service';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './components/home/home/home.component';
import { EventComponent } from './components/events/event/event/event.component';

@NgModule({
  declarations: [
    AppComponent,
    VenuesComponent,
    EventsComponent,
    HomeComponent,
    EventComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    NgbCarouselModule,
    HttpClientModule,
  ],
  providers: [
    DatePipe,
    Title,
    VenueService,
    EventService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
