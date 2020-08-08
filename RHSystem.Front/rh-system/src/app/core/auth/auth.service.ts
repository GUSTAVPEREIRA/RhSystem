import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { UserService } from '../user/user.service';
import { User } from '../user/user';

const API_URL = 'http://localhost:55793/api/'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private userService: UserService) { }

  authenticate(username: string, password: string) {
    return this.http.post(API_URL + 'Auth/Authenticate',
      {
        Username: username,
        Password: password
      },
      {
        observe: 'response'
      }
    ).pipe(
      tap(res => {
        // const user = authToken['user'];   
        const authToken = res.body;
        const bearerToken = authToken['bearerToken'];
        const user = authToken['user'] as User;
        this.userService.setToken(bearerToken, user);        
      })
    );
  }
}