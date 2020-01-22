import { Component, OnInit } from '@angular/core';

import { Dp01a110Service, ModalFormsService } from '../../../../services/services.index';
import { IDp01a110 } from '../../../../models/Formas/CNT/dp01a110';

import { ActivatedRoute,Router } from '@angular/router';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-web01f110-edit',
  templateUrl: './web01f110-edit.component.html',
  styleUrls: ['./web01f110.component.css']
})
export class Web01f110EditComponent implements OnInit {
  
  public _plan: IDp01a110 = { codigo: "", codigo_Aux: "", nombre: "", detalle: true, estado: "A", id: undefined };
  public isNew: boolean;

  constructor(private plan: Dp01a110Service,
    public modalForms: ModalFormsService,
    private router:Router,
    private activateRoute: ActivatedRoute) {
    this.activateRoute.params.subscribe(param => {
      if (param['id'] != "") {
        this.loadCta(param['id']);
      } else {
        this.encera();        
      }      
    });
  }

  ngOnInit() {
  }

  regresar() {
    this.router.navigate(['/plan.cuenta.root']);
  }

  loadCta(id: string) {
    this.plan.getPlanCtaByCodigo(id)
      .subscribe(planWS => {
        this._plan = planWS;
        this.isNew = false;
      }, error => console.error(error));
  }
  encera() {
    this._plan = { codigo: "", codigo_Aux: "", nombre: "", detalle: true, estado: "A", id: undefined };
    this.isNew = true;
  }
    
  saveCta(form:NgForm) {
    if (form.controls['codigo'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar cuenta contable");
      return;
    }
    if (form.controls['nombre'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar nombre de cuenta ");
      return;
    }

    let cuenta: IDp01a110;
    cuenta = {
      codigo: this._plan.codigo, nombre: this._plan.nombre, codigo_Aux: this._plan.codigo.replace(/\./gi, ""), estado: this._plan.estado,
      detalle: this._plan.codigo.substr(this._plan.codigo.length-1, 1) === "." ? false : true, id: this._plan.id
    }

    let resp: Observable<any>;

    //Grabamos Nuevo registro
    if (this.isNew) {
      resp = this.plan.SaveCta(cuenta);
    } else {      
      resp = this.plan.UpdateCtaById(cuenta);       
    }

    resp.subscribe(ok => {
      this.modalForms.messageboxComponent("Mensaje", "Guardado correctamente..!");
      this.router.navigate(['/plan.cuenta.root']);
      }, err => this.modalForms.messageboxComponent("Alerta", err.error));
  }
}
