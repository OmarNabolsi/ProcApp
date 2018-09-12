import { AuthGuard } from './_guards/auth.guard';
import { ValueListComponent } from './value-list/value-list.component';
import { ValueComponent } from './value/value.component';
import { HomeComponent } from './home/home.component';
import { Routes } from '@angular/router';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'values', component: ValueComponent, canActivate: [AuthGuard] },
            { path: 'lists', component: ValueListComponent },
        ]
    },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
