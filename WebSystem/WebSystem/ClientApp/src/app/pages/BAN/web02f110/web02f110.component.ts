import { Component, OnInit } from '@angular/core';

import { Dp02a110Service, ModalFormsService } from '../../../../services/services.index';
import { IDp02a110 } from '../../../../models/Formas/BAN/dp02a110';

import { Router } from '@angular/router';

@Component({
  selector: 'app-web02f110',
  templateUrl: './web02f110.component.html',
  styleUrls: ['./web02f110.component.css']
})
export class Web02f110Component implements OnInit {

  public ibancos: IDp02a110[] = [];  
  public page: number;
  public pageSize: number;

  constructor(private bcoService: Dp02a110Service,    
    public modalForms: ModalFormsService,    
    private router:Router) { }

  ngOnInit() {
    this.page = 1;
    this.pageSize = 10;
    this.cargarData();  
  }

  cargarData() {    
    this.bcoService.getBancos()
      .subscribe(ws => this.ibancos = ws,
        error => console.error(error));
  }

  public buscar(text: string): void {
    if (text.length >= 1) {
      this.bcoService.getBcoByNombre(text)
        .subscribe(x => this.ibancos = x, error => console.error(error));
    } else {
      this.cargarData();
    }
  }
    
  openForm(cod: string) {
    this.router.navigate(["/bancos.root/edit",cod.trim()])
  }
  
  deleteBco(bco: IDp02a110) {

    this.modalForms.messageboxOptions("Alerta", "Seguro que desea eliminar Banco?")
      .subscribe(result => {
        if (!result) { return; }
        this.bcoService.deleteBcoById(bco)
          .subscribe(x => { this.cargarData(); }, err => {
            this.modalForms.messageboxComponent("Alerta", err.error);
          });
      });
  }
}
