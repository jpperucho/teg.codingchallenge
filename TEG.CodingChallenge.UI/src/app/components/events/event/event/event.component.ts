import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from 'src/app/services/event.service';
import { VenueService } from 'src/app/services/venue.service';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {
  event: any;

  venueName: string;

  constructor(private activatedRoute: ActivatedRoute, private eventService: EventService, private venueService: VenueService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.eventService.getById(params["id"]).subscribe(res => {
        this.event = res;

        this.venueService.getById(this.event.venueId).subscribe(res => {
          this.venueName = res.name;
        }, (e) => {
          console.log(e);
        });
      }, (e) => {
        console.log(e);
      });
    });
  }
}
