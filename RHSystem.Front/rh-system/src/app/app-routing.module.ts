import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'

import { NotFoundPageComponent } from './errors/not-found-page/not-found-page.component';
import { UserFormComponent } from './home/login/user-form/user-form.component';
import { HomeModule } from './home/home.module';


const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'home'
    },
    {
        path: 'home',
        loadChildren:'./home/home.module#HomeModule'
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
        RouterModule.forRoot(routes, { useHash: true })
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }