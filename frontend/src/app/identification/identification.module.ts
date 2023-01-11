import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { IdentificationMainComponent } from './identification-main/identification-main.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputComponent } from '../common/ui-elements/input/input.component';
import { UiElementsModule } from '../common/ui-elements/ui-elements.module';
import { SubmitButtonComponent } from '../common/ui-elements/submit-button/submit-button.component';
import { IdentificationRouterModule } from './identification.router';
import { SignupComponent } from './signup/signup.component';
import { ButtonComponent } from '../common/ui-elements/button/button.component';



@NgModule({
  declarations: [
    LoginComponent,
    IdentificationMainComponent,
    InputComponent,
    SubmitButtonComponent,
    ButtonComponent,
    SignupComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IdentificationRouterModule
  ],
  exports: [
    IdentificationMainComponent
  ]
})
export class IdentificationModule { }
