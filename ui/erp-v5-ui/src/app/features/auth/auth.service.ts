import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from './login-response.model';
import { environment } from '../../../environments/evironment.prod';

@Injectable({ providedIn: 'root' })
export class AuthService {

    constructor(private http: HttpClient) { }

    login(credentials: { email: string; password: string }) {
        return this.http.post<LoginResponse>(
            `${environment.apiUrl}/auth/login`,
            credentials
        );
    }

    logout() {
        sessionStorage.removeItem('access_token');
    }
}
