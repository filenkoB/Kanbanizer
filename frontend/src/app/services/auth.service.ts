import { HttpClient, HttpHeaders, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Credential } from "../model/credential";
import { BaseService } from "./base.service";
import { HttpHeadersService } from "./http-headers.service";

export type TokenBody = {
    token: string;
};  

@Injectable()
export class AuthService extends BaseService {
    constructor(private readonly http : HttpClient, private readonly headerService : HttpHeadersService) {
        super();
    }

    public login(path : string, credentials : Credential) : Observable<TokenBody> {
        return this.http.post<TokenBody>(this.url + path, credentials, { headers: this.headerService.headers });
    }
}