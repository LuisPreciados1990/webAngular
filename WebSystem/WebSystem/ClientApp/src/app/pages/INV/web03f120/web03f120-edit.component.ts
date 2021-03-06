import { Component, OnInit} from '@angular/core';

import { Dp03a110Service, AlptablaService, Dp01a110Service, ModalFormsService } from '../../../../services/services.index';

import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';

import { IDp03a110 } from '../../../../models/Formas/INV/dp03a110';
import { IAlptabla } from '../../../../models/main/alptabla';
import { IDp01a110 } from '../../../../models/Formas/CNT/dp01a110';

import { MatDialog } from '@angular/material';

import { ModalHelpCntComponent } from '../../modal/modal-help-cnt/modal-help-cnt.component';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-web03f120-edit',
  templateUrl: './web03f120-edit.component.html',
  styleUrls: ['./web03f120.component.css']
})
export class Web03f120EditComponent implements OnInit {
  
  public _Prod: IDp03a110 = {
    pc_ncta: "", pc_ncta2: "", pc_ncta3: "", tipo: "N", estado: "A", no_parte: "", nombre: "", codinter: "", desunidad: "", aplica: "",
    modelo: "", pesocaja: 0, master: 0, codbarra: "", clase: "",subclase: "", subclase2: "", talla: "", color: "", marca: "", proveedor: "",
    origen: "", ubica: "BO:DE:GA", exmin: 0, exmax: 0, pordes: 0, cubicau: 0, cubicac: 0, vstock: true, iva_sn: true, modipvp: false,
    modidescri: false, pideser: false, tieice: false, pvpu1: 0, pvpu2: 0, desunidad2: "", hasta2: 0, pvpu3: 0, desunidad3: "", hasta3: 0,
    pvpu4: 0, desunidad4: "", hasta4: 0, pvpu5: 0, desunidad5: "", hasta5: 0, comenta:""
  };

  public _cta1: IDp01a110 = { codigo: "", nombre: "", codigo_Aux: "" };
  public _cta2: IDp01a110 = { codigo: "", nombre: "", codigo_Aux: "" };
  public _cta3: IDp01a110 = { codigo: "", nombre: "", codigo_Aux: "" };
  
  public isNew: boolean = false;

  public iUnid: IAlptabla[];
  public iClase: IAlptabla[];
  public iSubCla: IAlptabla[];
  public iSubCla2: IAlptabla[];
  public iTalla: IAlptabla[];
  public iColor: IAlptabla[];
  public iMarca: IAlptabla[];

  constructor(public prod: Dp03a110Service,
    public alpTabla: AlptablaService,
    public dialog: MatDialog,
    public ctaService: Dp01a110Service,
    private router: Router,
    private activateRoute: ActivatedRoute,
    public modalForms: ModalFormsService) {
    this.activateRoute.params.subscribe(param => {
      if (param['id'] != "") {
        this.loadItem(param['id']);
      } else {
        this.encera();
      }
    });
  }

  ngOnInit() {
    this.loadAlptables()
  }

  regresar() {
    this.router.navigate(['/productos.root']);
  }

  loadAlptables() {
    this.alpTabla.GetAlpTabla("I_TPUNI")
      .subscribe(x => this.iUnid = x, error => console.error(error));
    this.alpTabla.GetAlpTabla("I_CLASE")
      .subscribe(x => this.iClase = x, error => console.error(error));
    this.alpTabla.GetAlpTabla("I_SUBCLA")
      .subscribe(x => this.iSubCla = x, error => console.error(error));
    this.alpTabla.GetAlpTabla("I_SUBCLA2")
      .subscribe(x => this.iSubCla2 = x, error => console.error(error));
    this.alpTabla.GetAlpTabla("I_TALLA")
      .subscribe(x => this.iTalla = x, error => console.error(error));
    this.alpTabla.GetAlpTabla("I_COLOR")
      .subscribe(x => this.iColor = x, error => console.error(error));
    this.alpTabla.GetAlpTabla("I_MARCA")
      .subscribe(x => this.iMarca = x, error => console.error(error));
  }
  
  loadItem(item: string) {
    this.prod.GetProductoByCodigo(item)
      .subscribe(x => {
        this._Prod = x;
        this.loadCta1(this._Prod.pc_ncta);
        this.loadCta2(this._Prod.pc_ncta2);
        this.loadCta3(this._Prod.pc_ncta3);
      }, error => console.error(error));
    this.isNew = false;
  }

  loadCta1(cta: string) {
    if (cta != "") {
      this.ctaService.getPlanCtaByCodigo(cta).subscribe(cta => this._cta1 = cta);
    } else {
      this._cta1 = { codigo: "", nombre: "", codigo_Aux: "" };
    }
  }

  loadCta2(cta: string) {
    if (cta != "") {
      this.ctaService.getPlanCtaByCodigo(cta).subscribe(cta => this._cta2 = cta);
    } else {
      this._cta2 = { codigo: "", nombre: "", codigo_Aux: "" };
    }
  }

  loadCta3(cta: string) {
    if (cta != "") {
      this.ctaService.getPlanCtaByCodigo(cta).subscribe(cta => this._cta3 = cta);
    } else {
      this._cta3 = { codigo: "", nombre: "", codigo_Aux: "" };
    }
  }

  cargaProv() {
    console.log("DESAROLLANDO")
  }

  buscarProv() {
    console.log("DESAROLLANDO")
  }

  encera() {
    this._Prod= {
      pc_ncta: "", pc_ncta2: "", pc_ncta3: "", tipo: "N", estado: "A", no_parte: "", nombre: "", codinter: "", desunidad: "", aplica: "",
      modelo: "", pesocaja: 0, master: 0, codbarra: "", clase: "", subclase: "", subclase2: "", talla: "", color: "", marca: "", proveedor: "",
      origen: "", ubica: "BO:DE:GA", exmin: 0, exmax: 0, pordes: 0, cubicau: 0, cubicac: 0, vstock: true, iva_sn: true,
      modipvp: true, modidescri: true, pideser: false, tieice: false, pvpu1: 0, 
      pvpu2: 0, desunidad2: "", hasta2: 0, pvpu3: 0, desunidad3: "", hasta3: 0,
      pvpu4: 0, desunidad4: "", hasta4: 0, pvpu5: 0, desunidad5: "", hasta5: 0, comenta: ""
    };

    this._cta1 = { codigo: "", nombre: "", codigo_Aux: "" };
    this._cta2 = { codigo: "", nombre: "", codigo_Aux: "" };
    this._cta3 = { codigo: "", nombre: "", codigo_Aux: "" };

    this.isNew = true;
  }

  saveProd(form: NgForm) {    

    if (form.controls['no_parte'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar centro de costo");
      return;
    }
    if (form.controls['nombre'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar nombre de costo ");
      return;
    }
    //if (form.controls['nombre'].invalid) {
    //  this.modalForms.messageboxComponent("Alerta", "Debe ingresar nombre de costo ");
    //  return;
    //}
    
    let resp: Observable<any>;
    
    //Grabamos Nuevo registro
    if (this.isNew) {
      resp = this.prod.SaveItem(this._Prod);

    } else {      
      resp = this.prod.updateItemById(this._Prod);
    }
    
    resp.subscribe(ok => {
      this.modalForms.messageboxComponent("Mensaje", "Guardado correctamente..!");
      this.router.navigate(['/productos.root']);
    }, err => this.modalForms.messageboxComponent("Alerta", err.error));
  }
}
