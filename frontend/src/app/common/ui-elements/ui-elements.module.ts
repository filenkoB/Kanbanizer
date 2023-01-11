import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SectionSelectComponent } from './section-select/section-select.component';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    SectionSelectComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule
  ],
  exports: [
    SectionSelectComponent
  ]
})
export class UiElementsModule { }
