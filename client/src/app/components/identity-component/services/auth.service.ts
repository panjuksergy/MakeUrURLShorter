import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Login} from "../models/loginModel";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  public register(user: Login): Observable<any> {
    return this.http.post<any>('https://localhost:5004/api/UserAnonymous/register', user);
  }

  public login(user: Login): Observable<any> {
    return this.http.post('https://localhost:5003/api/identity/login', user, {responseType: 'text',
    });
  }
}
