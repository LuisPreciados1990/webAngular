import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common"

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DragDropModule } from '@angular/cdk/drag-drop';

import { PAGES_ROUTES } from './pages.routes';
import { SharedModule } from '../shared/shared.module';

//Componentes principales
import { PagesComponent } from './pages.component';
import { HomeComponent } from '../home/home.component';

//ModalForms
import { ModalDialogComponent } from './modal/modal-dialog/modal-dialog.component';
import { ModalHelpCliComponent } from './modal/modal-help-cli/modal-help-cli.component';
import { ModalHelpProdComponent } from './modal/modal-help-prod/modal-help-prod.component';
import { MessageboxComponent } from './modal/messagebox/messagebox.component';
import { ModalHelpCntComponent } from './modal/modal-help-cnt/modal-help-cnt.component';
import { ReportComponent } from './modal/Reportes/report/report.component';
import { DatePickerComponent } from './modal/date-picker/date-picker.component';
import { OptionsComponent } from './modal/options/options.component';
import { BusquedaComponent } from './modal/busqueda/busqueda.component';
import { ClaveComponent } from './modal/clave/clave.component';

import { DiarioComponent } from './modal/Reportes/diario/diario.component';

//Angular Material
import { MatDialogModule } from '@angular/material/dialog';
import {
  MatButtonModule, MatFormFieldModule, MatInputModule,
  MatRippleModule, MatToolbarModule, MatTabsModule
} from '@angular/material';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { NgbModule, NgbPaginationConfig } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//Componentes
import { Web01f110Component } from './CNT/web01f110/web01f110.component';
import { Web01f110EditComponent } from './CNT/web01f110/web01f110-edit.component';

import { Web01f120Component } from './CNT/web01f120/web01f120.component';
import { Web01f130EditComponent } from './CNT/web01f130/web01f130-edit.component';

import { Web01f130Component } from './CNT/web01f130/web01f130.component';

import { Web01f180Component } from './CNT/web01f180/web01f180.component';
import { Web01f180EditComponent } from './CNT/web01f180/web01f180-edit.component';

import { Web01f315Component } from './CNT/web01f315/web01f315.component';

import { Web02f110Component } from './BAN/web02f110/web02f110.component';
import { Web02f110EditComponent } from './BAN/web02f110/web02f110-edit.component';

import { Web03f120Component } from './INV/web03f120/web03f120.component';
import { Web03f120EditComponent } from './INV/web03f120/web03f120-edit.component';

import { Web03f130Component } from './INV/web03f130/web03f130.component';
import { Web03f320Component } from './INV/web03f320/web03f320.component';
import { Web03f340Component } from './INV/web03f340/web03f340.component';

import { CuentaAuxPipe } from '../../pipes/cuenta-aux.pipe';
import { CuentaPipe } from '../../pipes/cuenta.pipe';

//Pipes

@NgModule({
  declarations: [
    PagesComponent,
    HomeComponent,

    //ModalForms
    BusquedaComponent,
    ModalDialogComponent,
    ModalHelpCliComponent,
    ModalHelpProdComponent,
    MessageboxComponent,
    ModalHelpCntComponent,
    ReportComponent,
    DatePickerComponent,
    OptionsComponent,    
    ClaveComponent,
    DiarioComponent,

    //Componentes
    Web01f110Component,
    Web01f110EditComponent,

    Web01f120Component,
    
    Web01f130Component,
    Web01f130EditComponent,

    Web01f180Component,
    Web01f180EditComponent,

    Web01f315Component,

    Web02f110Component,
    Web02f110EditComponent,

    Web03f120Component,
    Web03f120EditComponent,

    Web03f130Component,
    Web03f320Component,
    Web03f340Component,

    //Pipes
    CuentaPipe,
    CuentaAuxPipe,    
  ],

  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    DragDropModule,
    
    SharedModule,
    PAGES_ROUTES,

    //Angular Material
    MatDialogModule, MatButtonModule, MatFormFieldModule, MatInputModule, MatRippleModule, MatToolbarModule,
    MatCardModule, MatTabsModule, MatCheckboxModule, MatRadioModule, MatSelectModule, NgbModule, BrowserAnimationsModule,
  ],

  exports: [
    HomeComponent,
    DragDropModule,

    //ModalForms
    BusquedaComponent,
    ModalDialogComponent,
    ModalHelpCliComponent,
    ModalHelpProdComponent,
    MessageboxComponent,
    ModalHelpCntComponent,
    ReportComponent,
    DatePickerComponent,
    OptionsComponent,    
    ClaveComponent,

    //Angular Material
    MatDialogModule, MatButtonModule, MatFormFieldModule, MatInputModule, MatRippleModule, MatToolbarModule,
    MatCardModule, MatTabsModule, MatCheckboxModule, MatRadioModule, MatSelectModule, NgbModule
  ],  
  // register the dynamic components here
  entryComponents: [
    BusquedaComponent,
    ModalDialogComponent,
    ModalHelpCliComponent,
    ModalHelpProdComponent,
    ModalHelpCntComponent,
    MessageboxComponent,
    DatePickerComponent,
    ReportComponent,
    OptionsComponent,    
    ClaveComponent]
})
export class PagesModule {}
