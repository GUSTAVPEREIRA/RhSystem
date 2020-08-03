import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../../core/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  loginForm: FormGroup;
  @ViewChild('userNameInput') userNameInput: ElementRef<HTMLInputElement>;

  constructor(private formBuilder: FormBuilder, private AuthService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]    
    });
  }

  login() {

    const username = this.loginForm.get('userName').value;
    const password = this.loginForm.get('password').value;

    this.AuthService.authenticate(username, password).subscribe(
      () => this.router.navigate(['rhsystem']),
      err => {
        console.log(err.error);        
        this.userNameInput.nativeElement.focus();
        this.loginForm.reset();

      });
  }

}
