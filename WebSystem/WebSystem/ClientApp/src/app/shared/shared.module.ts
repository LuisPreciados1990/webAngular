import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common"

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MenuComponent } from './menu/menu.component';
import { FooterComponent } from './footer/footer.component';
import { SpinnerComponent } from '../utilities/spinner/spinner.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    NavMenuComponent,
    MenuComponent,
    FooterComponent,
    SpinnerComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    RouterModule
  ],
  exports: [
    NavMenuComponent,
    MenuComponent,
    FooterComponent,
    SpinnerComponent
  ],
  providers: [
  ],
  entryComponents: [
  ]
})

export class SharedModule {}
