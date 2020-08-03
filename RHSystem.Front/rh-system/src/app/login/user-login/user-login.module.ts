import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { UserLoginComponent } from './user-login.component';
import { MessagesModule } from '../../shared/components/messages/messages.module';

@NgModule({
  declarations: [UserLoginComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MessagesModule,
    RouterModule
  ]
})
export class UserLoginModule { }