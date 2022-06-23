import { Component, OnInit, ViewChild } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { NgbCarousel, NgbSlideEvent, NgbSlideEventSource } from '@ng-bootstrap/ng-bootstrap';
import { Venue } from 'src/app/models/venue.model';
import { EventService } from 'src/app/services/event.service';
import { VenueService } from 'src/app/services/venue.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {
  events: any;

  venues: any;

  selectedVenue: any;

  constructor(private activatedRoute: ActivatedRoute, private title: Title, private eventsService: EventService, private venueService: VenueService) {
    this.title.setTitle("Events");

  }

  /** Initialize. */
  ngOnInit(): void {
    //this.fetch();

    this.fetchVenues();
  }

  /** Fetch. */
  fetch() {
    this.eventsService.fetch()
      .subscribe(res => {
        this.events = res;
      }, (e) => {
        // TODO: Error handling.
        console.log(e);
      });
  }

  /** Fetch venues. */
  fetchVenues() {
    this.venueService.fetch().subscribe(res => {
      this.venues = res;
      this.selectedVenue = this.venues[0];
      this.fetchByVenueId();
    }, (e) => {
      console.log(e);
    });
  }

  /** Fetch by venue ID. */
  fetchByVenueId() {
    if (this.selectedVenue === "") {
      this.fetch();
    }
    else {
      this.eventsService.fetchByVenueId(this.selectedVenue)
        .subscribe(res => {
          this.events = res;
        }, (e) => {
          // TODO: Error handling.
          console.log(e);
        });
    }
  }
}

