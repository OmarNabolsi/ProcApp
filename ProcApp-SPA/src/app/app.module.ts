import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxGalleryModule } from 'ngx-gallery';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ValueListComponent } from './values/value-list/value-list.component';
import { ValueCardComponent } from './values/value-card/value-card.component';
import { ValueDetailComponent } from './values/value-detail/value-detail.component';
import { ValueEditComponent } from './values/value-edit/value-edit.component';
import { ListsComponent } from './lists/lists.component';

import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';
import { ValueService } from './_services/value.service';
import { ValueDetailResolver } from './_resolvers/value-detail.resolver';
import { ValueListResolver } from './_resolvers/value-list.resolver';
import { ValueEditResolver } from './_resolvers/value-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';

export function tokenGetter() {
    return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      ValueListComponent,
      ValueCardComponent,
      ValueDetailComponent,
      ValueEditComponent,
      ListsComponent
   ],
   imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      NgxGalleryModule,
      JwtModule.forRoot({
          config: {
              tokenGetter: tokenGetter,
              whitelistedDomains: ['localhost:5000'],
              blacklistedRoutes: ['localhost:5000/api/auth']
          }
      })
   ],
   providers: [
      ErrorInterceptorProvider,
      AuthService,
      UserService,
      ValueService,
      AlertifyService,
      AuthGuard,
      ValueDetailResolver,
      ValueListResolver,
      ValueEditResolver,
      PreventUnsavedChanges
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
