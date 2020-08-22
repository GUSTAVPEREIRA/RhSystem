import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { UserFormModule } from './user-form/user-form.module';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    UserFormModule
  ],
  declarations: [

  ]
})
export class LoginModule { }