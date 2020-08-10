import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { UserLoginModule } from './user-login/user-login.module';
import { UserFormComponent } from './user-form/user-form.component';

@NgModule({
  imports: [
    CommonModule,
    UserLoginModule,
    ReactiveFormsModule,
    RouterModule,
    FormsModule
  ],
  declarations: [
    UserFormComponent
  ]
})
export class LoginModule { }