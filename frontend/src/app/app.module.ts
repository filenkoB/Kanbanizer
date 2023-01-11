import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRouterModule } from './app.router';
import { IdentificationModule } from './identification/identification.module';
import { MainModule } from './main/main.module';
import { HttpClientService } from './services/httpClient.service';
import { UiElementsModule } from './common/ui-elements/ui-elements.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    IdentificationModule,
    AppRouterModule,
    MainModule,
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    HttpClientService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
