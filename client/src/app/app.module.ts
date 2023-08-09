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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {UrlTableComponent} from "./components/datatable-component/url-table.component";
import { MainPageComponent } from './components/main-page-component/main-page.component';
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import { NavBarComponent } from './components/nav-bar-component/nav-bar.component';
import { NewUrlComponent } from './components/new-url-component/new-url.component';
import { PopUpComponent } from './components/pop-up-component/pop-up.component';
import { AboutPageComponent } from './components/about-page-component/about-page.component';
import { LogOutComponent } from './components/identity-component/pages/log-out-component/log-out.component';
import { ContactPageComponent } from './components/contact-page-component/contact-page.component';

@NgModule({
  declarations: [
    AppComponent,
    IdentityLoginPage,
    IdentityRegisterPage,
    UrlTableComponent,
    MainPageComponent,
    NavBarComponent,
    NewUrlComponent,
    NewUrlComponent,
    PopUpComponent,
    AboutPageComponent,
    LogOutComponent,
    ContactPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
