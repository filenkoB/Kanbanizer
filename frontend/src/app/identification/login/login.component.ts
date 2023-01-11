import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Credential } from 'src/app/model/credential';
import { AuthService, TokenBody } from 'src/app/services/auth.service';
import { HttpHeadersService } from 'src/app/services/http-headers.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss', '../../common/css/identification/identification-common.scss' ],
  providers: [ AuthService ]
})
export class LoginComponent implements OnInit {
  public formGroup : FormGroup;

  public login? : string;
  public password? : string;

  constructor(
      private readonly auth : AuthService,
      private readonly router : Router,
      private readonly headerService : HttpHeadersService) {
    this.formGroup = new FormGroup({
      login: new FormControl("", [Validators.required, Validators.email]),
    password: new FormControl("", [Validators.required, Validators.minLength(8)/*, Validators.maxLength(24)*/])
    });
  }

  public ngOnInit() : void {
    let identificationWrap = document.getElementsByClassName("identification-main-wrapper")[0] as HTMLElement;
    if (!identificationWrap) {
      return;
    }
    identificationWrap.style.height = "280px";
  }

  public logIn() : void {
    if (this.formGroup.invalid) {
      for (let controlName in this.formGroup.controls) {
        this.formGroup.controls[controlName].markAsTouched();
      }
      return;
    }
    const credentials = new Credential(this.login!, this.password!);
    this.auth.login("Auth/Login", credentials).subscribe((jwt : TokenBody) => {
      this.headerService.setAuthorizationHeader(jwt.token);
      this.router.navigate(['/']);
    }, (error) => (console.error(error)));
  }
}
