import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';

import {
  DpnumeroService, AlptablaService, Dp01a110Service, Dp01amovService, Dp02a130Service, PrintModalService, ModalFormsService,
  Dp02a110Service, Dp06a110Service, DpcabtraService
} from '../../../../services/services.index';

import { IDpnumero } from '../../../../models/Formas/CNT/dpnumero';
import { IAlptabla } from '../../../../models/main/alptabla';
import { IDpcabtra } from '../../../../models/Formas/CNT/dpcabtra';
import { ISp_Numsecu } from '../../../../models/StoredProcedure/sp_Numsecu';
import { IDp01amovEXT } from '../../../../models/Formas/CNT/dp01amov';
import { IDp02a130EXT } from '../../../../models/Formas/BAN/dp02a130';

import { MatDialog } from '@angular/material';

import { ModalHelpCntComponent } from '../../modal/modal-help-cnt/modal-help-cnt.component';

import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-web01f315',
  templateUrl: './web01f315.component.html',
  styleUrls: ['./web01f315.component.css']
})
export class Web01f315Component implements OnInit {
  env = environment;

  // #region Variables Generales
  public iTrn: IDpnumero[] = [];
  public iReten: IDpnumero[] = [];
    
  public indexTempo: number= 0;

  public tempoR: TempoR[] = [];  
  public codRt: IDp02a130EXT[] = [];

  public iTpComp: IAlptabla[] = [];
  public nuevoItem: boolean = false;
  public showFormItem: boolean = false;

  public nuevoReten: boolean = false;
  public ngEnabledEgreso: boolean = false;

  public nuevoTrn: boolean = true;
  public saving: boolean = false;
  public canceling: boolean = false;
  // #endregion

  // #region Variables Cabecera
  public _cabecera: IDpcabtra = {
    tipo_asi: "", asiento: "", fecha_asi: new Date(this.env.eFechaSys), desc_asi: "", beneficiar: "", debitos: 0,
    creditos: 0, cedruc: "",usuario: this.env.eUsuario, fechasys: new Date(), cerrado: false, anulado: false, ges_apl: 'CNT'}

  public _tipoTrn: IDpnumero = { tipo_asi: "", nombre: "", asiento: "", nomforma: "", tipo_com: "" }    
  // #endregion
  
  // #region Variables Cuenta
  public _detalle: IDp01amovEXT = {
    tipo_asi: "", asiento: "", linea: 0, fecha_asi: new Date(this.env.eFechaSys), codmov: "", nombreCta: "",
    tipo: "", refer: "", concepto: "", debe:0, haber:0, importe: 0, cerrado: false,anulado: false
  }  
  public _detalleT: IDp01amovEXT[] =[]
  public ngSaldo: number = 0;
  // #endregion

  // #region Variables Retencion
  public ngTpRete: string = "";
  public ngNTpRete: string = "";

  public ngNumRt: string = "";

  public ngCompRt: string = "";
  public ngNCompRt: string = "";

  public ngNumComproRt: string = "";
  public ngFechacad: string = "";
  public ngAutCmpVta: string = "";

  public ngProvee: string = "";
  public ngNProvee: string = "";

  public rowSelected: number;
  // #endregion

  // #region Variables Egreso
  public nuevoEgreso: boolean = false;
  public iEgre: any[] = [];  
  // #endregion

  @ViewChild('txtTrn') txtTrn: ElementRef;
  @ViewChild('txtCta') txtCta: ElementRef;
      
  constructor(public trn: DpnumeroService,
    public alpTabla: AlptablaService,
    public dialog: MatDialog,
    public cta: Dp01a110Service,
    public cabTra: DpcabtraService,
    public detalle: Dp01amovService,
    public rten: Dp02a130Service,
    public pintModal: PrintModalService,
    public modalForms: ModalFormsService,
    public egre: Dp02a110Service,
    public provee: Dp06a110Service) { }

  ngOnInit() {
    this.trn.getReten()
      .subscribe(x => this.iReten = x, error => console.error(error));

    this.alpTabla.GetAlpTabla("I_TIPCOM")
      .subscribe(x => this.iTpComp = x, error => console.error(error));

    this.rten.getRetTempo()
      .subscribe(x => this.codRt = x, error => console.error(error));

    this.egre.getBcoIngreso()
      .subscribe(x => this.iEgre = x, error => console.error(error));

    this.rowSelected = -1
  }
  
  public buscarTrn(): void {
    this.modalForms.dbHelpGen("TB01NUMERO").subscribe(result => {
      result === "" ? this._tipoTrn.tipo_asi = this._tipoTrn.tipo_asi : this._tipoTrn.tipo_asi = result;
      
      if (this._tipoTrn.tipo_asi === "") {
          this.ngEnabledEgreso = false;
          this.txtTrn.nativeElement.focus();
        }
        else { this.cargaTrn(); }
      });    
  }

  cargaTrn() {
    if (this._tipoTrn.tipo_asi.length > 0) {
      this.trn.getTrnCntByCodigo(this._tipoTrn.tipo_asi)
        .subscribe(x => {
          this._tipoTrn = x;
          this._tipoTrn.asiento = "";          
          this.ngEnabledEgreso = (x.tipo_com === "I" || x.tipo_com === "E");
        }, error => { this.enceratrn(); }
        );
    } else {
      this.enceratrn();
    }
  }

  trnOpciones() {    
    if (this._tipoTrn.asiento.length > 0 && this._tipoTrn.tipo_asi.length > 0) {

      this._tipoTrn.asiento = ("00000000" + this._tipoTrn.asiento).slice(-8);
      this.modalForms.optionsComponent().subscribe(resul => {

        switch (resul) {
            case 1: {
                this.pintModal.printModal(this._tipoTrn.tipo_asi, this._tipoTrn.asiento, this._tipoTrn.nomforma);
                //this.pintModal.printChequeEg(this._tipoTrn.tipo_asi, this._tipoTrn.asiento);
                this._tipoTrn.asiento = "";
                break;
            }
            case 2: {
                this.loadAsi(this._tipoTrn.tipo_asi, this._tipoTrn.asiento);
                break;
            }
            default: {
            this._tipoTrn.asiento = "";
              break;
            }
          } 
      });
    }
    else {
      this._tipoTrn.asiento = "";
    }
  }
  
  clickNuevoItem(newItem: boolean) {
    if (this._tipoTrn.nombre === "") {
      this.modalForms.messageboxComponent("Alerta","Debe seleccionar transacción");
      this.txtTrn.nativeElement.focus();
      return;
    }       

    this.nuevoItem = newItem;

    if (newItem) { this.enceraCta(); }
    else {
      if (this.indexTempo >= 0) {        
        this._detalle = this._detalleT[this.indexTempo];        
    }}
        
    if (this.indexTempo >= 0) { this.showFormItem = true; }
    else { this.showFormItem = false; }
  }  

  enceraCta() {
    this._detalle={
    tipo_asi: "", asiento: "", linea: 0, fecha_asi: new Date(this.env.eFechaSys), codmov: "", nombreCta: "",
    tipo: "", refer: "", concepto: "", debe: 0, haber: 0, importe: 0, cerrado: false, anulado: false
  }  
  }

  cancelTrn() {
    this.modalForms.messageboxOptions("Alerta", "Seguro que desea cancelar transacción?")
      .subscribe(result => {
        if (!result) { return; }
        this.enceratrn();
      });
  }

  enceratrn() {
    this.canceling = true;

    this.iTrn= [];
    this._detalleT = [];
    this.tempoR = [];    
    this.nuevoItem= false;

    this._tipoTrn = { tipo_asi: "", nombre: "", asiento: "", nomforma: "", tipo_com: "" }

    //Limpio Cabecera de transaccion
    this._cabecera= {
      tipo_asi: "", asiento: "", fecha_asi: new Date(this.env.eFechaSys), desc_asi: "", beneficiar: "", debitos: 0,
    creditos: 0, cedruc: "", usuario: this.env.eUsuario, fechasys: new Date(), cerrado: false, anulado: false, ges_apl: 'CNT'}
    
    this.ngEnabledEgreso = false;    
    this.ngSaldo= 0;    
    this.enceraCta();
    this.showFormItem = false;

    this.nuevoTrn= true;
    this.saving= false;
    this.canceling = false;    
  }

  public buscarCta(): void {
    const dialogRef = this.dialog.open(ModalHelpCntComponent, {
      width: '700px',
      data: { title: "Ayuda de Cuentas" },
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      result === "" ? this._detalle.codmov = this._detalle.codmov : this._detalle.codmov = result;
      if (this._detalle.codmov === "") {
        this.txtCta.nativeElement.focus();
      } else {
        this.cargaCta();
      }
    });
  }

  cargaCta() {
    if (this._detalle.codmov.length > 0) {
      this.cta.getPlanCtaByCodigo(this._detalle.codmov)
        .subscribe(x => { this._detalle.codmov = x.codigo_Aux; this._detalle.nombreCta = x.nombre; }, error => {
          this._detalle.codmov = ""; this._detalle.nombreCta = "";
        });
    }
  }

  saveTempo() {
    if (this._detalle.codmov === "") {
      this.modalForms.messageboxComponent("Alerta","Debe ingresar Cuenta");
      return;
    }  

    if (this._detalle.debe == 0 && this._detalle.haber == 0) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar valores");
      return;
    }  

    this._detalle.importe = this._detalle.debe > 0 ? this._detalle.debe : (this._detalle.haber * -1);
    
    if (this.nuevoItem){      
      this._detalleT.push(this._detalle);
    }
    else {      
      this._detalleT.splice(this.indexTempo, 1, this._detalle);
    }    

    this.showFormItem = false;
    this.df_totales();
  }

  deleteTempo() {
    this.modalForms.messageboxOptions("Alerta", "Seguro que desea eliminar registro?")
      .subscribe(result => {
          if (!result) { return; }
          this._detalleT.splice(this.indexTempo, 1);
          this.df_totales();
      });
  }
  
  df_totales() {
    this._cabecera.debitos = 0;
    this._cabecera.creditos = 0;

    for (let i of this._detalleT) {
      this._cabecera.debitos = this._cabecera.debitos + i.debe;
      this._cabecera.creditos = this._cabecera.creditos + i.haber;
      }
    this.ngSaldo = this._cabecera.debitos - this._cabecera.creditos
  }
    
  saveTrn() {
    this.saving = true;
    if (this.nuevoTrn) {
      //Sacamos numeracion
      let secu: ISp_Numsecu;
      secu = { tipo: this._tipoTrn.tipo_asi, modulo: '01', numero: '', devhva: true, fecha: new Date(this._cabecera.fecha_asi) }

      this.trn.secuanciaCnt(secu).subscribe(x => {
        //Obtengo el numero
        this._tipoTrn.asiento = x.secuencia;

        //Variables impresion de reporte
        let tipo = this._tipoTrn.tipo_asi; let numero = this._tipoTrn.asiento; let reporte = this._tipoTrn.nomforma;

        //Grabo cabecera
        //let cabeza1: IDpcabtra;      
        this._cabecera.tipo_asi = this._tipoTrn.tipo_asi,
        this._cabecera.asiento = this._tipoTrn.asiento,
        this.cabTra.saveCabTra(this._cabecera).subscribe();

        //Grabo Detalle      
        let linea = 0;

        for (let i = 0; i < this._detalleT.length; i++) {
          linea = linea + 1;
          this._detalleT[i].asiento = this._tipoTrn.asiento;
          this._detalleT[i].linea = linea;
        }

        this.detalle.save01Amov(this._detalleT).subscribe(ok => {
          //Confirmamos que los datos esten guardados en la tabla para despues imprimirlos          
          this.pintModal.printModal(tipo, numero, reporte);
        });

        this.enceratrn();
      }, error => console.error(error));
    }
    else {

      //Variables impresion de reporte
      let tipo = this._tipoTrn.tipo_asi; let numero = this._tipoTrn.asiento; let reporte = this._tipoTrn.nomforma;

      //Modifico Cabecera
      this.cabTra.updateCabTra(this._cabecera).subscribe();

      //Modifico Detalle
      let linea = 0;

      for (let i = 0; i < this._detalleT.length; i++) {
        linea = linea + 1;
        this._detalleT[i].asiento = this._tipoTrn.asiento;
        this._detalleT[i].linea = linea;
      }
      this.detalle.update01Amov(this._detalleT).subscribe(ok => {        
        this.pintModal.printModal(tipo, numero, reporte);
      });
      this.enceratrn();
    }
  }

  newReten() {
    if (this._tipoTrn.nombre === "") {
      this.modalForms.messageboxComponent("Alerta", "Debe seleccionar transacción");
      this.txtTrn.nativeElement.focus();
      return;
    }
    this.nuevoReten = true;    
  }

  addReten() {
    let codRt: IDp02a130EXT[] = this.codRt;

    let x = (document.getElementById("cboTpRete")) as HTMLSelectElement;
    this.ngNTpRete = x.options[x.selectedIndex].text;
    
    let y = (document.getElementById("cboCompRt")) as HTMLSelectElement;
    this.ngNCompRt = y.options[y.selectedIndex].text;
           
    this.tempoR.push({
      tipoRt: this.ngTpRete, nombreRt: this.ngNTpRete, numeroRt: this.ngNumRt, tipoComp: this.ngCompRt, nombreComp: this.ngNCompRt ,
      numeroComp: this.ngNumComproRt, fechacComp: this.ngFechacad, nAutorVta: this.ngAutCmpVta, infoRt: codRt, proveedorRt: this.ngProvee
    });
    let nLenAr = this.tempoR.length;
    this.openCloseRow(nLenAr-1);
  }

  public openCloseRow(idReserva: number): void {
    if (this.rowSelected === -1)
    {this.rowSelected = idReserva}
    else {
      if (this.rowSelected == idReserva)
      {this.rowSelected = -1}
      else
      {this.rowSelected = idReserva}
    }
  }

  calculaRt(indexI, indexJ, valor) {
    let porRet = this.tempoR[indexI].infoRt[indexJ].porcen;
    this.tempoR[indexI].infoRt[indexJ].base = valor;
    this.tempoR[indexI].infoRt[indexJ].valorRet = (valor * porRet) / 100;    
  }

  public buscarProv(): void {
    this.modalForms.dbHelpGen("TB06A110").subscribe(result => {
      result === "" ? this.ngProvee = this.ngProvee : this.ngProvee = result;

      if (this.ngProvee === "") {
          this.ngNProvee === "";
      }
      else { this.cargaProv(); }
    });
  }

  cargaProv() {
    if (this.ngProvee.length > 0) {      
      this.provee.getProveedorByCodigo(this.ngProvee)
        .subscribe(x => {
          this.ngNProvee = x.empresa;
        }, error => { this.ngProvee = ""; this.ngNProvee = "";}
        );
    } else {
      this.enceratrn();
    }
  }
  
  saveReten() {
    for (let i = 0; i < this._detalleT.length; i++) {
      if (this._detalleT[i].con_rt === "R") {
        this._detalleT.splice(i--, 1);
      }
    }
    
    for (let rtn of this.tempoR)
    {
      for (let rt of rtn.infoRt) {
        if (rt.base > 0){
          this._detalleT.push({
            tipo_asi: this._tipoTrn.tipo_asi, asiento: "", linea: 0, fecha_asi: this._cabecera.fecha_asi,
            codmov: rt.cuenta, nombreCta: rt.nombreCta, tipo: rtn.tipoRt, refer: rtn.numeroRt, debe: 0.00, haber: rt.valorRet,
            concepto: "", importe: (rt.valorRet * -1), cerrado: false, anulado: false, s_base0: 0, s_base12: 0,
            codpro: rtn.proveedorRt, numfac: rtn.numeroComp, con_rt: 'R', baseret: rt.base, por_ret: rt.porcen, numrete: rtn.tipoRt + rtn.numeroRt,
            codsri: rt.codsri, comproba: rtn.tipoComp, s_autoriza: rtn.nAutorVta, s_impcadu: rtn.fechacComp

          });
        }        
      }
    }        
    this.df_totales()
    this.nuevoReten = false;
  }

  deleteReten(index) {
    this.modalForms.messageboxOptions("Alerta", "Seguro que desea eliminar registro?")
      .subscribe(result => {
        if (!result) { return; }
        this.tempoR.splice(index, 1);
      });    
  }

  newEgreso() {
    this.nuevoEgreso = true;
  }

  saveEgre() {
    for (let i = 0; i < this._detalleT.length; i++) {
      if (this._detalleT[i].con_ch === "S") {
        this._detalleT.splice(i--, 1);
      }
    }
    
    for (let eg of this.iEgre) {      
      if (eg.valor > 0) {        
          this._detalleT.push({
            tipo_asi: this._tipoTrn.tipo_asi, asiento: "", linea: 0, fecha_asi: this._cabecera.fecha_asi,
            codmov: eg.codmov, nombreCta: eg.nombreCta, tipo: "CH", refer: "0", debe: 0.00, haber: eg.valor * 1,
            importe: eg.valor * 1, concepto: eg.comentario, con_ch: "S", chequeno: "0", fecche: eg.fecche,
            cerrado: false, anulado: false, s_base0: 0, s_base12: 0,
          });
      }
    }        
    this.df_totales()
    this.nuevoEgreso = false;
  }

  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
    }
  }

  loadAsi(tipo_asi: string, asiento: string) {
    //LLamamos a la cabecera de transacción
    this.cabTra.getDpcabtra(tipo_asi, asiento).subscribe(x => {      
      this._cabecera = x;

      //Si existe cabecera llamamos al detalle
      this.detalle.getD01amov(tipo_asi, asiento).subscribe(x => {
        this._detalleT = x;
      });

      this.nuevoTrn = false;
    }, err => {
        this.modalForms.messageboxComponent("Alerta", err.error)
        this._tipoTrn.asiento = "";
    });
  }
}

interface TempoR {
  tipoRt: string;
  nombreRt?: string;
  numeroRt: string;
  tipoComp?: string;
  nombreComp: string;
  numeroComp: string;
  fechacComp: string;
  nAutorVta: string;
  proveedorRt?: string;
  infoRt: IDp02a130EXT[];
}
