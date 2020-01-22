import { Component, OnInit } from '@angular/core';

import { Dp01a110Service, ModalFormsService } from '../../../../services/services.index';

import { IDp01a110 } from '../../../../models/Formas/CNT/dp01a110';

import { Router } from '@angular/router';

@Component({
  selector: 'app-web01f110',
  templateUrl: './web01f110.component.html',
  styleUrls: ['./web01f110.component.css']
})
export class Web01f110Component implements OnInit {
  public iplan: IDp01a110[] = [];    
  public page: number;
  public pageSize: number;  

  //https://medium.com/@azaharafernandezguizan/c%C3%B3mo-paginar-y-ordenar-una-tabla-en-angular-f%C3%A1cilmente-ba11ccb15214
  constructor(private plan: Dp01a110Service,
              public modalForms: ModalFormsService,
              private router: Router) { }

  ngOnInit() {
    this.page = 1;
    this.pageSize = 10;
    this.cargarData();    
  }

  cargarData() {    
    this.plan.getPlanCta()
      .subscribe(planWS => this.iplan = planWS,error => console.error(error));
  }

  public buscarCta(text: string): void {
    if (text.length >= 1) {
      this.plan.getPlanCtaByNombreOrAux(text)
        .subscribe(x => this.iplan = x, error => console.error(error));
    } else {
      this.cargarData();    
    }
  }
    
  openForm(id: string) {
    this.router.navigate(['/plan.cuenta.root/edit',id.trim()]);
  }
    
  deleteCta(cta: IDp01a110) {

    this.modalForms.messageboxOptions("Alerta", "Seguro que desea eliminar Cuenta?")
      .subscribe(result => {
        if (!result) { return; }
            this.plan.deleteCtaById(cta)
            .subscribe(x => { this.cargarData(); }, err => {
            this.modalForms.messageboxComponent("Alerta", err.error);
            });
      });    
  }  
}
