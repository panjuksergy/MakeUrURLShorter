import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {IdentityLoginPage} from "./components/identity-component/pages/identity-login-page/identity-login.page";
import {
  IdentityRegisterPage
} from "./components/identity-component/pages/identity-register-page/identity-register.page";

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: "full",
  },
  {
    path: '**',
    redirectTo: 'login',
  },
  {
    path: 'login',
    component: IdentityLoginPage
  },
  {
    path: 'register',
    component: IdentityRegisterPage
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
