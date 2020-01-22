import { Component, OnInit } from '@angular/core';

import { Dp01accoService, ModalFormsService } from '../../../../services/services.index';

import { IDp01acco } from '../../../../models/Formas/CNT/dp01acco';

import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-web01f180-edit',
  templateUrl: './web01f180-edit.component.html',
  styleUrls: ['./web01f180.component.css']
})
export class Web01f180EditComponent implements OnInit {
    
  public _ccos: IDp01acco = { id: undefined, cod_centro: "", nombre: "", sociedad: "", mostrar: true };
  public isNew: boolean = false;

  constructor(private ccos: Dp01accoService,
    public modalForms: ModalFormsService,
    private router: Router,
    private activateRoute: ActivatedRoute) {
    this.activateRoute.params.subscribe(param => {
      if (param['id'] != "") {
        this.loadCCo(param['id']);
      } else {
        this.encera();
      }
    });
  }

  ngOnInit() {
  }

  regresar() {
    this.router.navigate(['/centro.costo.contable.root']);
  }
  
  loadCCo(cco: string) {
    this.ccos.getCCostoByCodigo(cco)
      .subscribe(ccosWS => this._ccos = ccosWS, error => console.error(error));
    this.isNew = false;
  }

  encera() {
    this._ccos = { id: undefined, cod_centro: "", nombre: "", sociedad: "", mostrar: true };
    this.isNew = true;
  }

  saveCco(form: NgForm) {
    if (form.controls['cod_centro'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar centro de costo");
      return;
    }
    if (form.controls['nombre'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar nombre de costo ");
      return;
    }

    let resp: Observable<any>;
    //Grabamos Nuevo registro
    if (this.isNew) {
      resp = this.ccos.saveCCosto(this._ccos);

    } else {
      resp = this.ccos.updateCCostoById(this._ccos);
    }

    resp.subscribe(ok => {
      this.modalForms.messageboxComponent("Mensaje", "Guardado correctamente..!");
      this.router.navigate(['/centro.costo.contable.root']);
    }, err => this.modalForms.messageboxComponent("Alerta", err.error));

  }

}
