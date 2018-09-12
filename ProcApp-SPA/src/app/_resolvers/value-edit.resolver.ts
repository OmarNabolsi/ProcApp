import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { AlertifyService } from './../_services/alertify.service';
import { ValueService } from './../_services/value.service';
import { Value } from './../_models/value';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';

@Injectable()
export class ValueEditResolver implements Resolve<Value> {

    constructor(private valueService: ValueService,
        private router: Router,
        private alertify: AlertifyService
    ) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Value> {
        return this.valueService.getValue(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/values']);
                return of(null);
            })
        );
    }
}
