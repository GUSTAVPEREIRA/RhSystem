import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


import { UserNotTakenValidatorService } from './user-validator-not-taken.service';
import { UserForm } from './user-form';
import { UserFormService } from './user-form.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css'],
  providers: [UserNotTakenValidatorService]
})
export class UserFormComponent implements OnInit {

  userForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private UserNotTakenValidatorService: UserNotTakenValidatorService,
    private UserFormService: UserFormService,
    private Router: Router,
  ) { }

  ngOnInit(): void {

    this.userForm = this.formBuilder.group({
      userName: ['',
        [
          Validators.required
        ],
        [
          this.UserNotTakenValidatorService.checkUserNameTaken()
        ]
      ],
      password: ['', [
        Validators.required
      ]],
      regra: ['']
    });
  }

  userRegistry() {
    const newUser = this.userForm.getRawValue() as UserForm;
    newUser.RulesId = 1;
    this.UserFormService
      .UserRegistry(newUser)
      .subscribe(() => {
        this.Router.navigate(['']),
          err => console.log(err);
      });
  }
}