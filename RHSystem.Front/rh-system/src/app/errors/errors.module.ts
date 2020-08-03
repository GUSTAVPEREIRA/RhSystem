import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotFoundPageModule } from './not-found-page/not-found-page.module';

@NgModule({
  imports: [
    CommonModule,
    NotFoundPageModule
  ]
})
export class ErrorsModule { }
