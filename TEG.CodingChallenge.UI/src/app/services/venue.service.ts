import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Venue } from "../models/venue.model";
import { BaseService } from "./base.service";

@Injectable()
export class VenueService extends BaseService<Venue> {
    constructor(protected override http: HttpClient) { super(http, "venue"); }
}