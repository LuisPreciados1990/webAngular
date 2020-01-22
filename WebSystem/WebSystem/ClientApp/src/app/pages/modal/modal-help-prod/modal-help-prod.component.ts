import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Dp03a110Service } from '../../../../services/services.index';

import { IDp03a110 } from '../../../../models/Formas/INV/dp03a110';


@Component({
  selector: 'app-modal-help-prod',
  templateUrl: './modal-help-prod.component.html',
  styleUrls: ['./modal-help-prod.component.css']
})
export class ModalHelpProdComponent implements OnInit {

  public iProduc: IDp03a110[];

  public yesNo: Boolean;
  public title = "";
  public content = "";
  public codProd = "";

  constructor(public dialogRef: MatDialogRef<ModalHelpProdComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private prod: Dp03a110Service) {
      if (!data.title) { this.title = "Alerta.!"; }
      else { this.title = data.title }

      if (!data.content) { this.content = "Seguro?"; }
      else { this.content = data.content }

    this.yesNo = false;
  }


  ngOnInit() {
  }
  
  public buscarProducto(text: string): void {
    if (text.length >= 3) {
      this.prod.GetProductoByNombre(text)
        .subscribe(x => this.iProduc = x, error => console.error(error));
    } else {
      this.iProduc = [];
    }
  }

  public onDobleClick(no_parte: string): void {
    this.codProd = no_parte;
    this.onNoClick();
  }

  onNoClick(): void {
    this.dialogRef.close(this.codProd);
  }

}
