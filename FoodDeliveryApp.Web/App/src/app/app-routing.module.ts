import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router'
import { LoginComponent } from './login-registration/login/login.component';
//import { Listyourcomponent} from './your/list-yours'

const appRoutes: Routes = [
  //{path: 'list' , component:Listyourcomponent }
  { path: '', component: LoginComponent }
]



@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(appRoutes),
    CommonModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
