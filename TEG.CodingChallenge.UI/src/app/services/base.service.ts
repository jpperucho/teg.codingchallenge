import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { catchError } from "rxjs/operators";
import { throwError as observableThrowError } from "rxjs";

export class BaseService<T> {
    adminUrl: string;

    /** cTor. */
    constructor(protected http: HttpClient, private url: string) {
        this.adminUrl = `${environment.apiUrl}/api/${url}`;
    }
    
    /** Fetch. */
    fetch(path: string = "") {
        return this.http.get<Array<T>>(this.adminUrl + (path === "" ? "" : `/${path}`))
            .pipe(catchError((err: Response) => {
                return observableThrowError(err);
            }));
    }

    /** Get entity by ID */
    getById(id: string) {
        return this.http.get<T>(`${this.adminUrl}/${id}`)
            .pipe(catchError((err: Response) => {
                return observableThrowError(err);
            }));
    }
}
