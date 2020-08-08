import { Injectable } from '@angular/core';
import { TokenService } from '../token/token.service';
import { BehaviorSubject } from 'rxjs';
import { User } from './user';
import * as jwt_decode from 'jwt-decode'
import { UserToken } from './userToken';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private userSubject = new BehaviorSubject<User>(null);
  private userName: string;


  constructor(private tokenService: TokenService) {
    this.tokenService.hasToken() && this.decodeNotify();
  }

  setToken(token: string, user: User) {
    this.tokenService.setToken(token, user);
    this.userSubject.next(user);
  }

  getUser() {
    return this.userSubject.asObservable();
  }

  private decodeNotify() {
    const token = this.tokenService.getToken();
    const userAux = jwt_decode(token) as UserToken;
    let user: User = {
      username: userAux.unique_name,
      createdAt: null,
      deletedAt: null,
      id: null,
      password: null,
      updatedAt: null
    };

    this.userName = user.username;
    this.userSubject.next(user);
  }

  logout() {
    this.tokenService.removeToken();
    this.userSubject.next(null);
  }

  isLogged() {
    return this.tokenService.hasToken();
  }

  getUserName() {
    return this.userName;
  }
}