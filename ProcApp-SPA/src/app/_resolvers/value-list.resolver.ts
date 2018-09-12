import { Observable, of } from 'rxjs';
import { AlertifyService } from './../_services/alertify.service';
import { ValueService } from './../_services/value.service';
import { Value } from './../_models/value';
import { Resolve, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ValueListResolver implements Resolve<Value[]> {

    constructor(private valueService: ValueService,
        private router: Router,
        private alertify: AlertifyService
    ) {}

    resolve(): Observable<Value[]> {
        return this.valueService.getValues().pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
