import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { UserLoginModule } from './user-login/user-login.module';

@NgModule({  
  imports: [
    CommonModule,
    UserLoginModule,
    ReactiveFormsModule,
    RouterModule
  ]
})
export class LoginModule { }
