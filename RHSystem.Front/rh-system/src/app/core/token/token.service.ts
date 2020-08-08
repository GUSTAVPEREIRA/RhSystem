import { Injectable } from '@angular/core';
import { User } from '../user/user';

const KEY = 'BearerToken';
const USERKEY = 'userKey';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  hasToken() {
    return !!this.getToken();
  }

  setToken(token, user: User) {
    window.localStorage.setItem(KEY, token);
    window.localStorage.setItem(USERKEY, user.username);
  }

  getToken() {
    return window.localStorage.getItem(KEY);
  }

  getUser() {
    return window.localStorage.getItem(USERKEY);
  }

  removeToken() {
    window.localStorage.removeItem(KEY);
    window.localStorage.removeItem(USERKEY);
  }
}