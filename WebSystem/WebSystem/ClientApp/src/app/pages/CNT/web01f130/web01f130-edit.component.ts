import { Component, OnInit } from '@angular/core';

import { DpnumeroService, ModalFormsService } from '../../../../services/services.index';
import { IDpnumero } from '../../../../models/Formas/CNT/dpnumero';

import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-web01f130-edit',
  templateUrl: './web01f130-edit.component.html',
  styleUrls: ['./web01f130.component.css']
})
export class Web01f130EditComponent implements OnInit {

  public _dpnum: IDpnumero = {tipo_asi: "", nombre: "", asiento: "00000000", nomforma: "", tipo_com: "D", modulo: "", ch_boucher: "",
                      tiene_at: "", secumes: "N", serie_rt: "", autori_rt: "", celectro: "N", es_retenci: "N", fiscal: false, id: undefined};
  public isNew: boolean = false;
  
  constructor(private dpnum: DpnumeroService,
    public modalForms: ModalFormsService,
    private router: Router,
    private activateroute: ActivatedRoute) {
    this.activateroute.params.subscribe(param => {
      if (param['id'] != "") {
        this.loadInfo(param['id']);        
      } else {
        this.encera();
      }
    });
  }

  ngOnInit() {}

  regresar() {
    this.router.navigate(['/comprobantes.contables.root']);
  }
    
  encera() {
    this._dpnum = {
      tipo_asi: "", nombre: "", asiento: "00000000", nomforma: "", tipo_com: "D", modulo: "", ch_boucher: "",
      tiene_at: "", secumes: "N", serie_rt: "", autori_rt: "", celectro: "N", es_retenci: "N", fiscal: false, id: undefined};
    this.isNew = true;
  }

  loadInfo(codigo:string) {
    this.dpnum.getTrnCntByCodigo(codigo)
      .subscribe(planWS => this._dpnum = planWS, error => console.error(error));
    this.isNew = false;
  }

  save(form: NgForm) {
    if (form.controls['tipo_asi'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar codigo");
      return;
    }
    if (form.controls['nombre'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar nombre");
      return;
    }
    if (form.controls['asiento'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar numeración");
      return;
    }

    let resp: Observable<any>;

    //Grabamos Nuevo registro
    if (this.isNew) {
      resp = this.dpnum.saveDpnumero(this._dpnum);

    } else {
      resp = this.dpnum.updateDpnumero(this._dpnum);
    }

    resp.subscribe(ok => {
      this.modalForms.messageboxComponent("Mensaje", "Guardado correctamente..!");
      this.router.navigate(['/comprobantes.contables.root']);
    }, err => this.modalForms.messageboxComponent("Alerta", err.error));
  }
}
