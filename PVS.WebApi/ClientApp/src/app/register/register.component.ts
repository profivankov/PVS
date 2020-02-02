import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  form: FormGroup;
  loading = false;
  submitted = false;
  errorMessage: any;

  constructor(private userService: UserService, private formBuilder: FormBuilder, private router: Router) {  }

  ngOnInit() {
    this.form = this.formBuilder.group(
      {
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        email: ['', Validators.required],
        password: ['', [Validators.required, Validators.minLength(6)]]
      }
    );
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;

    if (!this.form.valid) {
      return;
    }

    this.loading = true;
    this.userService.saveUser(this.form.value)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['/login', { queryParams: { registered: true } }]);
        },
        error => {
          this.errorMessage = error;
          this.loading = false;
        });

  }
}

