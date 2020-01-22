import { Component, OnInit, Inject } from '@angular/core';

import { Dp01a110Service } from '../../../../services/services.index';

import { IDp01a110 } from '../../../../models/Formas/CNT/dp01a110';

import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { MessageboxComponent } from '../messagebox/messagebox.component';

@Component({
  selector: 'app-modal-help-cnt',
  templateUrl: './modal-help-cnt.component.html',
  styleUrls: ['./modal-help-cnt.component.css']
})
export class ModalHelpCntComponent implements OnInit {
  
  public ICta: IDp01a110[];

  public yesNo: Boolean;
  public mayor: Boolean;
  public title = "";
  public content = "";
  public codCta = "";

  constructor(public dialogRef: MatDialogRef<ModalHelpCntComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private cta: Dp01a110Service,
    public dialog: MatDialog,) {
    if (!data.title) { this.title = "Alerta.!"; }
    else { this.title = data.title }

    if (!data.content) { this.content = "Seguro?"; }
    else { this.content = data.content }

    if (!data.mayor) { this.mayor = false; }
    else { this.mayor = data.mayor }

    this.yesNo = false;
  }

  ngOnInit() {
  }
  
  public buscarCta(text: string): void {
    if (text.length >= 3) {
      this.cta.getPlanCtaByNombre(text)
        .subscribe(x => this.ICta = x, error => console.error(error));
    } else {
      this.ICta = [];
    }
  }

  public onDobleClick(codigo_aux: string , detalle:Boolean): void {

    if (!this.mayor && !detalle) {
      //alert("");

      const dialogRef = this.dialog.open(MessageboxComponent, {
        width: '350px',
        data: { title: "Error", content: "No puede seleccionar cuenta de Mayor" }
      });

      return
    }

    this.codCta = codigo_aux;
    this.onNoClick();
  }

  onNoClick(): void {
    this.dialogRef.close(this.codCta);
  }

}
