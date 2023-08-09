import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CreateNewUrlModel} from "../models/create-new-url.model";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class NewUrlService {
  private baseUrl = 'http://localhost:5259/api/UrlAuthorize';

  constructor(private http: HttpClient) { }

  public createNewUrl(req: CreateNewUrlModel): Observable<any>{
    return this.http.post(`${this.baseUrl}/createUrl`,req, { responseType: 'text'});
  }
}
