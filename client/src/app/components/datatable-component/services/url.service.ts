import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {GetAllRequestModel} from "../models/get-all-request.model";
import {DeleteRequestModel} from "../models/delete-request.model";

@Injectable({
  providedIn: 'root',
})
export class UrlService {
  private baseUrl = 'http://localhost:5259/api';

  constructor(private http: HttpClient) {}

  getAllUrls(getAllreq: GetAllRequestModel): Observable<any> {
    return this.http.post(`${this.baseUrl}/url/getAllProducts`, getAllreq);
  }
  deleteUrl(dellreq: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/UrlAuthorize/deleteUrl/`+dellreq);
  }
  getUrlDetails(id: string ): Observable<any> {
    return this.http.get(`${this.baseUrl}/UrlAuthorize/details/`+id);
  }
}
