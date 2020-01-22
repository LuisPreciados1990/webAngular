import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

import { ModalFormsService, Dp03acomService, Dp05a110Service, Dp03a110Service, AlptablaService } from '../../../../services/services.index';

import { IDpinvcab } from '../../../../models/Formas/INV/dpinvcab';
import { IDp03acom } from '../../../../models/Formas/INV/dp03acom';
import { IDp03amovEXT } from '../../../../models/Formas/INV/dp03amov';
import { IAlptabla } from '../../../../models/main/alptabla';
import { IDp05a110 } from '../../../../models/Formas/COB/dp05a110';
import { IDp03a110 } from '../../../../models/Formas/INV/dp03a110';

import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-web03f320',
  templateUrl: './web03f320.component.html',
  styleUrls: ['./web03f320.component.css']
})
export class Web03f320Component implements OnInit {

  env = environment;

  public nuevoItem: boolean = false;
  public showFormItem: boolean = false;

  // #region Cabecera
  public _cabecera: IDpinvcab
  public _tipoTrn: IDp03acom
  // #endregion

  // #region Detalle
  public _detalle: IDp03amovEXT
  public _detalleT: IDp03amovEXT[]
  // #endregion

  // #region
  public dbBode: IAlptabla
  public dbVende: IAlptabla
  public dbCLi: IDp05a110
  public _Prod: IDp03a110
  // #endregion

  @ViewChild('txtTrn') txtTrn: ElementRef;

  constructor(public modalForms: ModalFormsService,
              public tiposcService: Dp03acomService,
              private cliService: Dp05a110Service,
              private prodService: Dp03a110Service,
              private alpService: AlptablaService) { }
  
  ngOnInit() {
    this.enceratrn();
  }

  buscarTrn(){
    this.modalForms.dbHelpGen("TBTPVEN").subscribe(result => {
      result === "" ? this._tipoTrn.codigo = this._tipoTrn.codigo : this._tipoTrn.codigo = result;

      if (this._tipoTrn.codigo === "") {
        this.txtTrn.nativeElement.focus();
      }
      else { this.cargaTrn(); }
    });
  }

  cargaTrn() {
    if (this._tipoTrn.codigo.length > 0) {
      this.tiposcService.getTransacINv(this._tipoTrn.codigo,"V")
        .subscribe(x => {          
          this._tipoTrn = x;
          this._tipoTrn.numero = "";
        }, error =>  this.enceratrn());
    } else {
      this.enceratrn();
    }
  }

  trnOpciones() {
    if ((this._tipoTrn.numero && this._tipoTrn.codigo) && (this._tipoTrn.numero.length > 0 && this._tipoTrn.codigo.length > 0)) {

      this._tipoTrn.numero = ("00000000" + this._tipoTrn.numero).slice(-8);
      this.modalForms.optionsComponent().subscribe(resul => {

        switch (resul) {
          case 1: {
            //this.pintModal.printModal(this._tipoTrn.codigo, this._tipoTrn.numero, this._tipoTrn.nomforma);
            this._tipoTrn.numero = "";
            break;
          }
          case 2: {
            //this.loadAsi(this._tipoTrn.codigo, this._tipoTrn.numero);
            break;
          }
          default: {
            this._tipoTrn.numero = "";
            break;
          }
        }
      });
    }
    else {
      this._tipoTrn.numero = "";
    }
  }

  enceratrn() {

    this._tipoTrn = { codigo: "", nombre: "", tipo: "", forma: "" }

    this._cabecera={
    tipo: "", numero: "", numero_b: "", fecha_tra: new Date(this.env.eFechaSys), usercla: this.env.eUsuario,
      userfec: new Date(), anulada: false, comenta:""
    }    
    
    this._detalle = { tipo: "", numero: "", linea: 0, fecha_tra: new Date(this.env.eFechaSys), tipo_t: "" }
    this._detalleT = []

    this.dbBode = { codigo: "", nombre: "", master:""}
    this.dbVende = { codigo: "", nombre: "", master: "" }

    this.dbCLi= { codigo: "", empcli: "", ruc: "", fono1: "", email: "", direccion: "" }

    this._Prod = {no_parte:"", nombre:""}

    this.nuevoItem = false;    
    this.showFormItem = false;
    
  }

  buscarBode() {
    this.modalForms.dbHelpGen("TBALPBODE").subscribe(result => {
      result === "" ? this._cabecera.bodega = this._cabecera.bodega : this._cabecera.bodega = result;

      if (this._cabecera.bodega === "") {
        this.dbBode.codigo = "";
        this.dbBode.nombre = "";
      }
      else { this.cargaBode(); }
    });
  }

  cargaBode() {
    if (this._cabecera.bodega && this._cabecera.bodega.length > 0) {
    this.alpService.getAlpTablaCod("I_BODE",this._cabecera.bodega)
      .subscribe(x => this.dbBode = x, error => {
        this._cabecera.bodega = "";
        this.dbBode.codigo = "";
        this.dbBode.nombre = "";
        });
    }
  }

  buscarVende() {
    this.modalForms.dbHelpGen("TBALPVENDE").subscribe(result => {
      result === "" ? this._cabecera.vendedor = this._cabecera.vendedor : this._cabecera.vendedor = result;

      if (this._cabecera.vendedor === "") {
        this.dbVende.codigo = "";
        this.dbVende.nombre = "";
      }
      else { this.cargaVende(); }
    });
  }

  cargaVende() {
    if (this._cabecera.vendedor && this._cabecera.vendedor.length > 0) {
      this.alpService.getAlpTablaCod("I_VENDE", this._cabecera.vendedor)
        .subscribe(x => this.dbVende = x, error => {
          this._cabecera.vendedor = "";
          this.dbVende.codigo = "";
          this.dbVende.nombre = "";
        });
    }
  }

  buscarCli() {
    this.modalForms.dbHelpGen("TB05A110").subscribe(result => {
      result === "" ? this._cabecera.prov_cli = this._cabecera.prov_cli : this._cabecera.prov_cli = result;
      if (this._cabecera.prov_cli != "") {
        this.cargaCli();
      }      
    });
  }

  cargaCli() {
    if (this._cabecera.prov_cli && this._cabecera.prov_cli.length > 0) {
      this.cliService.GetClienteByCodigo(this._cabecera.prov_cli)
        .subscribe(result => this.dbCLi = result, error => {
          this.dbCLi = { codigo: "", empcli: "", ruc: "", fono1: "", email: "", direccion: "" }
        });
    }
  }

  buscarProd() {
    this.modalForms.dbHelpGen("TB03A110").subscribe(result => {
      result === "" ? this._Prod.no_parte = this._Prod.no_parte : this._Prod.no_parte = result;
      if (this._Prod.no_parte != "") {
        this.cargaCli();
      }
    });
  }

  cargaProd() {
    if (this._Prod.no_parte && this._Prod.no_parte.length > 0) {

      this.prodService.GetProductoByCodigo(this._Prod.no_parte)
        .subscribe(result => this._Prod = result, error => {
          this._Prod = { no_parte: "", nombre: "" }
        });
    }
  }

  clickNuevoItem(form: NgForm) {
    if (form.controls['codigo'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar transacción");
      return;
    }
    if (form.controls['bodega'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar bodega");
      return;
    }
    if (form.controls['prov_cli'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar cliente");
      return;
    }
    this.nuevoItem = true;    
  }
}
