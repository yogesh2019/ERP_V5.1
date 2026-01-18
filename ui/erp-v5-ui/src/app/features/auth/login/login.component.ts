import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { SHARED_IMPORTS } from '../../../../shared/shared.import';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [SHARED_IMPORTS, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm;

  constructor(private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      email: [''],
      password: ['']
    });
  }
}
