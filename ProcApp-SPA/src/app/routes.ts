import { ValueListResolver } from './_resolvers/value-list.resolver';
import { ValueDetailResolver } from './_resolvers/value-detail.resolver';
import { AuthGuard } from './_guards/auth.guard';
import { ValueListComponent } from './values/value-list/value-list.component';
import { ValueDetailComponent } from './values/value-detail/value-detail.component';
import { ListsComponent } from './lists/lists.component';
import { HomeComponent } from './home/home.component';
import { Routes } from '@angular/router';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'values', component: ValueListComponent, resolve: {values: ValueListResolver} },
            { path: 'values/:id', component: ValueDetailComponent, resolve: {value: ValueDetailResolver} },
            { path: 'lists', component: ListsComponent },
            { path: '', component: HomeComponent }
        ]
    },
    { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
