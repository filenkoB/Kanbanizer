import { HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: "root" })
export class HttpHeadersService {
    private _headers : HttpHeaders = new HttpHeaders({"Access-Control-Allow-Origin": "http://localhost:4200"});

    get headers() : HttpHeaders {
        this._headers = this._headers.set("Authorization", "Bearer " + sessionStorage.getItem("Token"));
        return this._headers;
    }

    public setAuthorizationHeader(jwt : string) : void {
        sessionStorage.setItem("Token", jwt);
    }
}