import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseService } from "./base.service";
import { HttpHeadersService } from "./http-headers.service";

@Injectable({ providedIn: "root" })
export class HttpClientService extends BaseService {
    constructor(private readonly http : HttpClient, private readonly headerService : HttpHeadersService) {
        super();
    }

    public getAll<T>(path : string) : Observable<T[]> {
        return this.http.get<T[]>(this.url + path, { headers: this.headerService.headers });
    }

    public get<T>(path : string) : Observable<T> {
        return this.http.get<T>(this.url + path, { headers: this.headerService.headers });
    }

    public post<T>(path : string, entity : T) : Observable<T> {
        return this.http.post<T>(this.url + path, entity, { headers: this.headerService.headers });
    }

    public put<T>(path : string, entity : T) : Observable<T> {
        return this.http.put<T>(this.url + path, entity, { headers: this.headerService.headers });
    }

    public delete<T>(path : string) : Observable<T> {
        return this.http.delete<T>(this.url + path, { headers: this.headerService.headers });
    }
}