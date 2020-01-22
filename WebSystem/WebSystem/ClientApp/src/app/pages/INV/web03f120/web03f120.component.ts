import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Dp03a110Service } from '../../../../services/services.index';

import { IDp03a110 } from '../../../../models/Formas/INV/dp03a110';

import { MatDialog } from '@angular/material';

import { ModalHelpCntComponent } from '../../modal/modal-help-cnt/modal-help-cnt.component';
import { MessageboxComponent } from '../../modal/messagebox/messagebox.component';

@Component({
  selector: 'app-web03f120',
  templateUrl: './web03f120.component.html',
  styleUrls: ['./web03f120.component.css']
})
export class Web03f120Component implements OnInit {

  public iProd: IDp03a110[] = [];
  public verTb: boolean = true;
  public page: number;
  public pageSize: number;

  constructor(public prod: Dp03a110Service,    
    public dialog: MatDialog,
    private router:Router) { }

  ngOnInit() {
    this.page = 1;
    this.pageSize = 10;
    this.cargaProd();
  }
    
  cargaProd() {
      this.prod.GetProductos()
      .subscribe(x => this.iProd = x, error => console.error(error));
  }

  buscarProducto(text: string) {
    if (text.length >= 3) {
      this.prod.GetProductoByNombre(text)
        .subscribe(x => this.iProd = x, error => console.error(error));
    } else {
      this.iProd = [];
    }
  }

  openForm(codigo:string) {
    this.router.navigate(["/productos.root/edit", codigo.trim()])
  }

  //deleteProd(bco: IDp02a110) {

  //  this.modalForms.messageboxOptions("Alerta", "Seguro que desea eliminar Banco?")
  //    .subscribe(result => {
  //      if (!result) { return; }
  //      this.bcoService.deleteBcoById(bco)
  //        .subscribe(x => { this.cargarData(); }, err => {
  //          this.modalForms.messageboxComponent("Alerta", err.error);
  //        });
  //    });
  //}

}
