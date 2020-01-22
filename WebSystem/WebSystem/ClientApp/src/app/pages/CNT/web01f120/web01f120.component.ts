import { Component, OnInit } from '@angular/core';

import { DasbalService, ModalFormsService } from '../../../../services/services.index';

import { IDasbal } from '../../../../models/Formas/CNT/dasbal';

import { Subscription } from 'rxjs';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-web01f120',
  templateUrl: './web01f120.component.html',
  styleUrls: ['./web01f120.component.css']
})
export class Web01f120Component implements OnInit {

  public isEdit: boolean = false;
  public _dasbal: IDasbal = {id: undefined, activo: "",pasivo:"",capital:"",egresos:"",ingresos:"",ord_activo:"",
                            ord_pasivo:"",resultadod:"",resultadoa:"",acumuladod:"",acumuladoa:"",eg_cencos:false,
                            in_cencos:false, caja:"",ventas:"",cto_venta:"",gasto_des:"",trasnpor:"",impuesto:"",
                            inter_por: ""};

  public _subscriptions: Subscription[] = [];

  constructor(private dasbal: DasbalService,
              public modalForms: ModalFormsService) { }

  ngOnInit() {
    this.cargarData();
  }

  cargarData() {    
    this._subscriptions.push(this.dasbal.getDasBal()
      .subscribe(dasb => this._dasbal = dasb ,
        error => console.error(error)));
  }

  save(form: NgForm) {
    
  }
}
