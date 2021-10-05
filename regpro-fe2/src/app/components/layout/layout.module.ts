import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { BaseLayoutComponent } from './base-layout.component';
import { FooterComponent } from './footer/footer.component';
import { TopnavbarComponent } from './topnavbar/topnavbar.component';
import { SideNavigationComponent } from './side-navigation/side-navigation.component';

@NgModule({
  declarations: [
    BaseLayoutComponent,
    FooterComponent,
    TopnavbarComponent,
    SideNavigationComponent
  ],
  imports: [
    BrowserModule,
    RouterModule
  ],
  exports: [
    BaseLayoutComponent,
    FooterComponent
  ],
})

export class LayoutModule { }
