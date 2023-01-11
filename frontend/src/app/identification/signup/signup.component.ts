import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss', '../../common/css/identification/identification-common.scss' ]
})
export class SignupComponent implements OnInit {
  public formGroup : FormGroup;

  constructor() {
    this.formGroup = new FormGroup({
      login: new FormControl("", Validators.email),
      password: new FormControl("", [Validators.minLength(8), Validators.maxLength(24)])
    });
  }

  public ngOnInit() : void {
    let identificationWrap = document.getElementsByClassName("identification-main-wrapper")[0] as HTMLElement;
    if (!identificationWrap) {
      return;
    }
    identificationWrap.style.height = "400px";
  }

  public signup() : void {

  }
}
