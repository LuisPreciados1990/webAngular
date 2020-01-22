import { Component, OnInit } from '@angular/core';

import { DpnumeroService, ModalFormsService } from '../../../../services/services.index';
import { IDpnumero } from '../../../../models/Formas/CNT/dpnumero';
import { Router } from '@angular/router';

@Component({
  selector: 'app-web01f130',
  templateUrl: './web01f130.component.html',
  styleUrls: ['./web01f130.component.css']
})
export class Web01f130Component implements OnInit {

  public iDpnum: IDpnumero[] = [];
  public page: number;
  public pageSize: number;  

  constructor(private dpnum: DpnumeroService,
    public modalForms: ModalFormsService,
    private router:Router) { }

  ngOnInit() {
    this.page = 1;
    this.pageSize = 10;
    this.cargarData();
  }

  cargarData() {    
    this.dpnum.getDPNumero()
      .subscribe(planWS => this.iDpnum = planWS, error => console.error(error));
  }

  public buscarInfo(text: string): void {
    if (text.length >= 1) {
      this.dpnum.getTrnCntByNombre(text)
        .subscribe(x => this.iDpnum = x, error => console.error(error));
    } else {
      this.cargarData();
    }
  }
    
  openForm(id:string) {
    this.router.navigate(['/comprobantes.contables.root/edit',id.trim()]);
  }
  
  delete(vr: IDpnumero) {

    this.modalForms.messageboxOptions("Alerta", "Seguro que desea eliminar transacción?")
      .subscribe(result => {
              if (!result) { return; }
                  this.dpnum.deleteDpnumeroById(vr)
                .subscribe(x => { this.cargarData(); }, err => {
                this.modalForms.messageboxComponent("Alerta", err.error);
            });
      });
  }
}
