import { Component } from '@angular/core';
import {Login} from './../../models/loginModel';
import {AuthService} from './../../services/auth.service';

@Component({
  templateUrl: './identity-login.page.html',
  styleUrls: ['./identity-login.page.scss']
})
export class IdentityLoginPage{
  title = 'client';
  userLogin = new Login();

  constructor(private authService: AuthService) {
  }
  login(userLogin: Login){
    this.authService.login(userLogin).subscribe((token: string) => {
      localStorage.setItem('authToken', token);
    });
  }

}
