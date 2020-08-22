import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { UserLoginModule } from './login/user-login/user-login.module';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    UserLoginModule,
    RouterModule,
    HomeRoutingModule
  ],
  exports: [
  ]
})
export class HomeModule { }
