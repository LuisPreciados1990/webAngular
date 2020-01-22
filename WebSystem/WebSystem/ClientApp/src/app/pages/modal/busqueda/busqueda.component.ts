import { Component, OnInit, Inject } from '@angular/core';

import { HelpGenService } from '../../../../services/services.index';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-busqueda',
  templateUrl: './busqueda.component.html',
  styleUrls: ['./busqueda.component.css']
})
export class BusquedaComponent implements OnInit {
  
  public tabla: any[];
  public _help: string="";
  
  public title = "Ayuda y busqueda";
  public codigo = "";

  //constructor(public dialogRef: MatDialogRef<BusquedaComponent>,
  //  @Inject(MAT_DIALOG_DATA) public data: any,
  //  private help: HelpGenService) {
  //  if (!data.help) { this._help = ""; }
  //  else { this._help = data.help }
  //}

  ngOnInit() {
    //if (this._help.trim() != "") {
    //  this.help.getHelpGen(this._help.trim().toLocaleUpperCase())
    //    .subscribe(x => this.tabla = x, error => console.error(error));
    //}
  }
  
  public buscar(text: string): void {
    //if (text.length >= 3) {

    //  //this._subscriptions.push(this.trn.getTrnCntByNombre(text)
    //  //  .subscribe(x => this.tabla = x, error => console.error(error)));

    //} else {
    //  this.tabla = [];
    //}
  }

  //public onDobleClick(codigo: string): void {
  //  this.codigo = codigo;
  //  this.onNoClick();
  //}

  //onNoClick(): void {
  //  this.dialogRef.close(this.codigo);
  //}
}
