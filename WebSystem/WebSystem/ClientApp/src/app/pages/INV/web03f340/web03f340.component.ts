import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatDialog } from '@angular/material';

import {
  Dp03acomService, Dp05a110Service, Dp03a110Service, AlptablaService, DpinvcabService, Dp03amovService
} from '../../../../services/services.index';

import { IDp03acom } from '../../../../models/Formas/INV/dp03acom';
import { IDp05a110 } from '../../../../models/Formas/COB/dp05a110';
import { IDp03a110 } from '../../../../models/Formas/INV/dp03a110';
import { IAlptabla } from '../../../../models/main/alptabla';
import { IDpinvcab } from '../../../../models/Formas/INV/dpinvcab';
import { IDp03amov } from '../../../../models/Formas/INV/dp03amov';

import { environment } from '../../../../environments/environment';

import { ModalHelpCliComponent } from '../../modal/modal-help-cli/modal-help-cli.component';
import { ModalHelpProdComponent } from '../../modal/modal-help-prod/modal-help-prod.component';
import { MessageboxComponent } from '../../modal/messagebox/messagebox.component';
import { ModalDialogComponent } from '../../modal/modal-dialog/modal-dialog.component';

@Component({
  selector: 'app-web03f340',
  templateUrl: './web03f340.component.html',
  styleUrls: ['./web03f340.component.css']
})
export class Web03f340Component implements OnInit  {
  env = environment;

  public iComp: IDp03acom[];
  public iTrn: IDp03acom;
  public iClient: IDp05a110[];
  public cliente: IDp05a110;
  public iProduc: IDp03a110[];
  public tempo: Tempo[]= [];
  public iBode: IAlptabla[];
  public iVende: IAlptabla[];

  public pDate =this.env.eFechaSys;

  public selectedCli: string="";
  public ncliente: string = "";
  public rcliente: string = "";
  public tcliente: string = "";
  public ecliente: string = "";
  public dcliente: string = "";

  public selectedProd: string = "";
  public nProducto: string = "";
  public nPresenta: string = "";
  public pCantidad: number = 0;
  public pPreciou: number = 0;
  public pDecuento: number = 0;
  public pPreciot: number = 0;  
  public pIvasn: string = "S";


  public pSubtotal: number = 0;
  public pIva0: number = 0;
  public pIvaTax: number = 0;
  public pTotalIva: number = 0;
  public pDescuTrn: number = 0;
  public pTotalTrn: number = 0;
    
  public nuevoItem: boolean = false;

  @ViewChild('cboTipo') cboTipo: ElementRef;
  @ViewChild('cboBodega') cboBodega: ElementRef;  
  @ViewChild('txtcli') txtcli: ElementRef;
  @ViewChild('txtprod') txtprod: ElementRef;  
  @ViewChild('cboVende') cboVende: ElementRef;
  @ViewChild('rComenta') rComenta: ElementRef;


  public selectedTrn: string = "";
  public selectedBod: string = "";
  public selecteddBod: string = "";
  public txtcomenta: string = "";
  public selectedVende: string = "";

  constructor(private comp: Dp03acomService,
              private cli: Dp05a110Service,
              private prod: Dp03a110Service,
              private alp: AlptablaService,
              public dialog: MatDialog,
              public cabeza: DpinvcabService,
              public detalle: Dp03amovService) { }

  ngOnInit() {    
    this.loadComprobaInv();
    this.loadAlp();
    this.selectedCli = this.env.eConsFinal;
    this.cargaCli();
  }

  loadComprobaInv() {
    this.comp.GetComprobaInvByGrupo("P")
      .subscribe(x => this.iComp = x  , error => console.error(error));
  }

  loadAlp() {    
    this.alp.GetAlpTabla("I_BODE")
      .subscribe(x => this.iBode = x, error => console.error(error));

    this.alp.GetAlpTabla("I_VENDE")
      .subscribe(x => this.iVende = x, error => console.error(error));
  }
     
  public buscarCliente(): void {    
    const dialogRef = this.dialog.open(ModalHelpCliComponent, {
      width: '700px',      
      data: { title: "Ayuda de Clientes" },
      disableClose: true 
    });

    dialogRef.afterClosed().subscribe(result => {
      result === "" ? this.selectedCli = this.selectedCli : this.selectedCli = result;
      if (this.selectedCli === "") {
        this.txtcli.nativeElement.focus();
      } else {
        this.cargaCli();
        this.rComenta.nativeElement.focus();        
      }      
    });
    
  }

  public buscarProducto(): void {
    const dialogRef = this.dialog.open(ModalHelpProdComponent, {
      width: '700px',
      data: { title: "Ayuda de Productos" },
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      result === "" ? this.selectedProd = this.selectedProd : this.selectedProd = result;
      if (this.selectedProd === "") {
        this.txtprod.nativeElement.focus();
      } else {
        this.cargaProd();        
      }
    });

  }

  cargaCli() {    
    if (this.selectedCli && this.selectedCli.length > 0) {
      this.cli.GetClienteByCodigo(this.selectedCli)
        .subscribe(x => this.valoresCli(x), error => this.enceraCli());
    } else {
      this.enceraCli();
    }
  }

  cargaProd() {
    if (this.selectedProd && this.selectedProd.length > 0) {
      this.prod.GetProductoByCodigo(this.selectedProd)
        .subscribe(x => this.valoresProd(x), error => this.enceraProd());
    } else {
      this.enceraProd();
    }
  }

  valoresCli(cliente: IDp05a110) {    
    if (cliente) {      
      this.ncliente = cliente.empcli;
      this.rcliente = cliente.ruc;
      this.tcliente = cliente.fono1;
      this.ecliente = cliente.email;
      this.dcliente = cliente.direccion;
    } 
  }

  valoresProd(producto: IDp03a110) {
    if (producto) {
        this.nProducto = producto.nombre;
        this.nPresenta = producto.desunidad;
        this.pCantidad= 0;
        this.pPreciou= producto.pvpu1;
        this.pDecuento= 0;
        this.pPreciot = 0;
        this.pIvasn = "S";
      
    }
  }

  enceraCli() {
    this.selectedCli= "";
    this.ncliente= "";
    this.rcliente= "";
    this.tcliente= "";
    this.ecliente= "";
    this.dcliente= "";
  }

  enceraProd() {
    this.selectedProd = "";
    this.selecteddBod = this.selectedBod;
    this.nProducto = "";
    this.nPresenta = "";
    this.pCantidad = 0;
    this.pPreciou = 0;
    this.pDecuento = 0;
    this.pPreciot = 0;  
  }

  clickNuevoItem(newItem: boolean) {

    if (this.selectedTrn === "") {
      const dialogRef = this.dialog.open(MessageboxComponent, {
        width: '300px',
        data: { title: "Alerta", content: "Debe seleccionar transacción" }        
      });      
      this.cboTipo.nativeElement.focus();
      return;
    }
    if (this.selectedBod === "") {
      const dialogRef = this.dialog.open(MessageboxComponent, {
        width: '300px',
        data: { title: "Alerta", content: "Debe seleccionar bodega" }
      });
      this.cboBodega.nativeElement.focus();
      return;
    }  
    if (this.selectedCli === "") {
      const dialogRef = this.dialog.open(MessageboxComponent, {
        width: '300px',
        data: { title: "Alerta", content:"Debe seleccionar cliente " }        
      });
      this.txtcli.nativeElement.focus();
      return;
    }

    this.nuevoItem = newItem;
    this.enceraProd();
    //this.txtprod.nativeElement.focus();
  }

  fCalcula() {    
    this.pPreciot = this.pCantidad * this.pPreciou;    
  }

  df_totales() {    
    let subTotal = 0;
    let iva0 = 0;
    let ivaTax = 0;
    let totalIva = 0;

    for (let i of this.tempo) {
      subTotal = subTotal + i.precio_t;
      if (i.ivans === "S") {
        ivaTax = ivaTax + i.precio_t 
        totalIva = totalIva + (i.precio_t * (this.env.eIva / 100));
      } else { iva0 = iva0 + i.precio_t}

    }
    this.pSubtotal = Number(subTotal.toFixed(2));
    this.pIva0 = Number(iva0.toFixed(2));;
    this.pIvaTax = Number(ivaTax.toFixed(2));
    this.pTotalIva = Number(totalIva.toFixed(2));

    this.pDescuTrn= 0;
    this.pTotalTrn = Number((this.pIva0 + this.pIvaTax + this.pTotalIva).toFixed(2));
  }

  saveTempo() {
    
    let tempo = {
      no_parte: this.selectedProd, nombre: this.nProducto, cantidad: this.pCantidad,
      precio_u: this.pPreciou, descuento: this.pDecuento, precio_t: this.pPreciot,
      ivans: this.pIvasn, desunidad: this.nPresenta, bod: this.selecteddBod
    };

    this.tempo.push(tempo);
    this.nuevoItem = false;
    this.df_totales();
  }

  deleteTempo(index) {

      const dialogRef = this.dialog.open(ModalDialogComponent, {
        width: '350px',
        data: { title: "Alerta", content: "Segudo que desea eliminar registro?" }
      });

      dialogRef.afterClosed().subscribe(result => {
        if (!result) { return; }
        this.tempo.splice(index, 1);
        this.df_totales();
      });
  }

  saveTrn() {
    if (this.selectedTrn === "") {
      alert("Debe ingresar transacción..!");
      this.cboTipo.nativeElement.focus();
      return;
    }
    if (this.selectedVende === "") {
      alert("Debe ingresar vendedor..!");
      this.cboVende.nativeElement.focus();
      return;
    }
    
    let trn :IDp03acom = JSON.parse(JSON.stringify(this.iComp.filter(x => x.codigo === this.selectedTrn))); // return implicito

    //Grabo cabecera
    let cabeza1: IDpinvcab;
    cabeza1 = {
      tipo: trn[0].codigo, numero: "00000000", numero_b: "", grupo: trn[0].grupo, tipo_t: trn[0].inventario === "S" ? trn[0].tipo : "",
      fecha_tra: new Date(this.pDate), fecha_ven: new Date(this.pDate), bodega: this.selectedBod, prov_cli: this.selectedCli,
      vendedor: this.selectedVende, tp_precio: "A", total_mov: this.pSubtotal, pordes: 0, total_des: 0, poriva: this.env.eIva,
      total_iva: this.pTotalIva, total_trn: this.pTotalTrn, userfec: new Date(), usercla: this.env.eUsuario, comenta: this.txtcomenta,
      base_0: this.pIva0, base_tax: this.pIvaTax, estadoFac: true,
    };    
    //console.log(cabeza1);

    this.cabeza.saveInvCab(cabeza1).subscribe();

    //Grabo Detalle
    let detalle1: IDp03amov;
    let linea= 0;
    for (let i of this.tempo) {
      linea = linea + 1;
      detalle1 = {
        tipo: trn[0].codigo, numero: "00000000", linea: linea, tipo_t: trn[0].inventario === "S" ? trn[0].tipo : "", presenta: "U", factor: 1,
        fecha_tra: new Date(this.pDate), touch: "", no_parte: i.no_parte, consumo: "", bodega: this.selectedBod, cantidad: i.cantidad,
        precio_u: i.precio_u, precio_t: i.precio_t, poriva: this.env.eIva, valiva: 0, pordes: 0, valdes: 0, precio_ne: i.precio_t,
        servicio: "", desitem: 0, tprecio: "A", desit: 0, nservicio: i.nombre,costFactor: 0, totFactor: 0, codFactor: "", canFactor: 0, partidaICE: ""
      };
      console.log(detalle1);
      this.detalle.saveInvDet(detalle1).subscribe();
    }
    //https://www.youtube.com/watch?v=aqCMlI6Wq64
    alert("OK");
  } 
}

interface Tempo {  
  no_parte: string;
  nombre: string;
  cantidad: number;
  precio_u: number;
  descuento: number;
  precio_t: number;
  ivans: string;
  desunidad: string;
  bod: string;
}
