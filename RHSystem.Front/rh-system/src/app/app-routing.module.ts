import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'

import { AuthGuard } from './core/auth/auth.guard';
import { NotFoundPageComponent } from './errors/not-found-page/not-found-page.component';
import { UserLoginComponent } from './login/user-login/user-login.component';
import { UserFormComponent } from './login/user-form/user-form.component';


const routes: Routes = [
    {
        path: '',
        component: UserLoginComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'user/form',
        component: UserFormComponent
    },
    {
        path: '**', component: NotFoundPageComponent
    }
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