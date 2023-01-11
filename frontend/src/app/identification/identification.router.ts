import { NgModule } from "@angular/core";
import { NgModel } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { IdentificationMainComponent } from "./identification-main/identification-main.component";
import { LoginComponent } from "./login/login.component";
import { SignupComponent } from "./signup/signup.component";

const routes : Routes = [{
    path: "identification", component: IdentificationMainComponent, children: [
        { path: "login", component: LoginComponent },
        { path: "signup", component: SignupComponent }
    ]
}];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class IdentificationRouterModule {}
