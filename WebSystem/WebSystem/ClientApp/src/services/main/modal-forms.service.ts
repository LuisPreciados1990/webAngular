import { Injectable } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { OptionsComponent } from '../../app/pages/modal/options/options.component';
import { MessageboxComponent } from '../../app/pages/modal/messagebox/messagebox.component';
import { ModalDialogComponent } from '../../app/pages/modal/modal-dialog/modal-dialog.component';
import { BusquedaComponent } from '../../app/pages/modal/busqueda/busqueda.component';

@Injectable({
  providedIn: 'root'
})
export class ModalFormsService {

  constructor(public dialog: MatDialog) { }

  optionsComponent() {
    const dialogRef = this.dialog.open(OptionsComponent, {
      width: '50%',
      height: '16%',
      data: { title: "Alerta", content: "Segudo que desea eliminar registro?" }
    });
    return dialogRef.afterClosed();
  }

  messageboxComponent(title:string,message:string) {
    this.dialog.open(MessageboxComponent, {
      width: '300px',
      data: { title: title, content: message }
    });    
  }

  messageboxOptions(title: string, message: string) {
    const dialogRef = this.dialog.open(ModalDialogComponent, {
      width: '350px',
      data: { title: title, content: message }
    });
    return dialogRef.afterClosed();
  }

  dbHelpGen(help:string) {
    const dialogRef = this.dialog.open(BusquedaComponent, {
      width: '700px',
      height: '750px',
      data: {help: help},
      disableClose: true
    });
    return dialogRef.afterClosed();
  }

}
