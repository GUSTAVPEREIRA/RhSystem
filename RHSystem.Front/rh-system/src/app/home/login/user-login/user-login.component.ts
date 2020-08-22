import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { Router } from '@angular/router';
import { AuthService } from '../../../core/auth/auth.service';
import { PlatFormDetectorService } from '../../../core/platform-detector/platform-detector.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  loginForm: FormGroup;
  @ViewChild('userNameInput') userNameInput: ElementRef<HTMLInputElement>;

  constructor(private formBuilder: FormBuilder, private AuthService: AuthService,
    private router: Router, private PlatFormDetectorService: PlatFormDetectorService) { }

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
        
        this.loginForm.reset();
        this.PlatFormDetectorService.isPlatFormBrowser() && this.userNameInput.nativeElement.focus();
      });
  }

}
