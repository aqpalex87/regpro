import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ApiService } from "src/app/services/api.service";

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    constructor(
      private http: HttpClient,
      private router: Router,
      private readonly apiService: ApiService
    ) { }

    login(username: string, password: string) {
        return this.apiService.post('/Authentication/login', { userName: username, password: password })
            // .pipe(map((res: any) => {
            //     // login successful if there's a jwt token in the response
            //     if (res && res.token) {
            //         // store username and jwt token in local storage to keep user logged in between page refreshes
            //         localStorage.setItem('currentUser', JSON.stringify({ username, token: res.token }));
            //     }
            // }));
    }

    logout() {
        // remove user from local storage to log user out
        this.router.navigate(['/login']);
        localStorage.removeItem('currentUser');
    }
}
