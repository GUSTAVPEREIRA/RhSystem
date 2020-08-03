import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'

import { NotFoundPageComponent } from './errors/not-found-page/not-found-page.component';
import { UserLoginComponent } from './login/user-login/user-login.component';


const routes: Routes = [
    { path: '', component: UserLoginComponent },
    { path: '**', component: NotFoundPageComponent }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }