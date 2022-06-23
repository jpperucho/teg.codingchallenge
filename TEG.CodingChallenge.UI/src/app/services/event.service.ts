import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";

@Injectable()
export class EventService extends BaseService<Event> {
    constructor(protected override http: HttpClient) { super(http, "event"); }
 
    /** Fetch by venue ID. */
    fetchByVenueId(venueId: number) {
        return super.fetch(`byvenueid/${venueId}`);
    }
}