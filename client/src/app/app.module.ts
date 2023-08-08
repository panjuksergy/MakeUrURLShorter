import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {FormsModule} from "@angular/forms";
import {AuthInterceptor} from "./components/identity-component/services/auth.interceptor";
import {IdentityLoginPage} from "./components/identity-component/pages/identity-login-page/identity-login.page";
import {
  IdentityRegisterPage
} from "./components/identity-component/pages/identity-register-page/identity-register.page";
import { MainPageComponent } from './components/main-page-component/main-page.component';
import {DataTablesModule} from "angular-datatables";

@NgModule({
  declarations: [
    AppComponent,
    IdentityLoginPage,
    IdentityRegisterPage,
    MainPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    DataTablesModule,
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
