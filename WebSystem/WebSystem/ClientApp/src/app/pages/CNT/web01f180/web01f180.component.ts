import { Component, OnInit } from '@angular/core';

import { Dp01accoService, ModalFormsService } from '../../../../services/services.index';

import { IDp01acco } from '../../../../models/Formas/CNT/dp01acco';
import { Router } from '@angular/router';

@Component({
  selector: 'app-web01f180',
  templateUrl: './web01f180.component.html',
  styleUrls: ['./web01f180.component.css']
})
export class Web01f180Component implements OnInit {

  public iccos: IDp01acco[] = [];  
  public page: number;
  public pageSize: number;  

  constructor(private ccos: Dp01accoService,
    public modalForms: ModalFormsService,
    private router:Router
  ) { }

  ngOnInit() {
    this.page = 1;
    this.pageSize = 10;
    this.cargarData();  
  }

  cargarData() {    
      this.ccos.getCCosto()
      .subscribe(ccosWS => this.iccos = ccosWS,error => console.error(error));
  }

  public buscarCCo(text: string): void {
    if (text.length >= 1) {
      this.ccos.getCCostoByNombre(text)
        .subscribe(x => this.iccos = x, error => console.error(error));
    } else {
      this.cargarData();
    }
  }
  
  openForm(cod:string) {
    this.router.navigate(["/centro.costo.contable.root/edit",cod.trim()]);
  }
  
  deleteCCo(cco: IDp01acco) {
    this.modalForms.messageboxOptions("Alerta", "Seguro que desea eliminar Centro de Costo?")
      .subscribe(result => {
        if (!result) { return; }
        this.ccos.deleteCCostoById(cco)
          .subscribe(x => { this.cargarData(); }, err => {
            this.modalForms.messageboxComponent("Alerta", err.error);
          });
      });
  }  
}
