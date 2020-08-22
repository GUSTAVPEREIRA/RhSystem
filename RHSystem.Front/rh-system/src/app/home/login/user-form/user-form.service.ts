import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { UserForm } from './user-form';
import { UserService } from '../../../core/user/user.service';

const API = "http://localhost:55793/api"
var headers;

@Injectable({
  providedIn: 'root'
})
export class UserFormService {
  constructor(private http: HttpClient, private UserService: UserService) {
    headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.UserService.getToken()}`
    });
  }

  checkUserNameTaken(userName: string) {
    return this.http.get(`${API}/User/UsernameExists/${userName}`, {
      headers: headers,
      observe: 'response'
    });
  }

  UserRegistry(newUser: UserForm) {
    return this.http.post(`${API}/User/CreateUser`, newUser, {
      headers: headers,
      observe: 'response'
    });
  }
}