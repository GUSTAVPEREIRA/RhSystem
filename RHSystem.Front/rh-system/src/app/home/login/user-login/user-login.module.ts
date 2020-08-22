import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { UserLoginComponent } from './user-login.component';
import { MessagesModule } from '../../../shared/components/messages/messages.module';

@NgModule({
  declarations: [UserLoginComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MessagesModule,
    FormsModule
  ],
  exports: []
})
export class UserLoginModule { }