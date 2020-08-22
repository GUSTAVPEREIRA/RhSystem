import { Injectable } from "@angular/core";
import { AbstractControl } from '@angular/forms';

import { debounceTime, switchMap, map, first } from 'rxjs/operators';

import { UserFormService } from './user-form.service';

@Injectable(    )
export class UserNotTakenValidatorService {

    constructor(private userFormService: UserFormService) {

    }

    checkUserNameTaken() {
        return (control: AbstractControl) => {
            return control.valueChanges
                .pipe(debounceTime(300))
                .pipe(switchMap(userName => this.userFormService.checkUserNameTaken(userName)))
                .pipe(map(result => {
                    return !!result &&  result.body['message'] == true ? { userNameTaken: result.body['message'] } : null;
                }))
                .pipe(first());
        }
    }
}