import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material';

import { Dp02a110Service, ModalFormsService, Dp01a110Service } from '../../../../services/services.index';

import { IDp02a110 } from '../../../../models/Formas/BAN/dp02a110';

import { ModalHelpCntComponent } from '../../modal/modal-help-cnt/modal-help-cnt.component';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-web02f110-edit',
  templateUrl: './web02f110-edit.component.html',
  styleUrls: ['./web02f110.component.css']
})
export class Web02f110EditComponent implements OnInit {

  public ibanco: IDp02a110 = { id: undefined, codigobco: "", codmov: "", nombrebco: "" };
  public isNew: boolean = false;  

  constructor(private bcoService: Dp02a110Service,
    public ctaService: Dp01a110Service,
    public modalForms: ModalFormsService,
    public dialog: MatDialog,
    private router: Router,
    private activateRoute: ActivatedRoute) {
    this.activateRoute.params.subscribe(param => {
      if (param['id'] != "") {
        this.loadBco(param['id']);
      } else {
        this.encera();
      }
    });
  }

  ngOnInit() {}

  regresar() {
    this.router.navigate(['/bancos.root']);
  }
    
  encera() {
    this.ibanco = { id: undefined, codigobco: "", codmov: "", nombrebco: "" };
    this.isNew = true;
  }
    
  loadBco(cod: string) {       
    this.bcoService.getBcoByCodigo(cod)
      .subscribe(ws => this.ibanco = ws,
        error => console.error(error));
    this.isNew = false;
  }
  
  saveBco(form: NgForm) {
    if (form.controls['codigobco'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar codigo de Banco");
      return;
    }
    if (form.controls['nombrebco'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar nombre de Banco ");
      return;
    }
    if (form.controls['codmov'].invalid) {
      this.modalForms.messageboxComponent("Alerta", "Debe ingresar Cuenta contable de Banco ");
      return;
    }

    let resp: Observable<any>;

    //Grabamos Nuevo registro
    if (this.isNew) {
      resp = this.bcoService.saveBco(this.ibanco);
    } else {
      resp = this.bcoService.updateBcoById(this.ibanco);
    }

    resp.subscribe(ok => {
      this.modalForms.messageboxComponent("Mensaje", "Guardado correctamente..!");
      this.router.navigate(['/bancos.root']);
    }, err => this.modalForms.messageboxComponent("Alerta", err.error));
  }

  public buscarCta(): void {
    const dialogRef = this.dialog.open(ModalHelpCntComponent, {
      width: '700px',
      data: { title: "Ayuda de Cuentas" },
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      result === "" ? this.ibanco.codmov = this.ibanco.codmov : this.ibanco.codmov = result;
      if (this.ibanco.codmov != "") {
        this.cargaCta();
      }
    });
  }

  cargaCta() {
    if (this.ibanco.codmov.length > 0) {
      this.ctaService.getPlanCtaByCodigo(this.ibanco.codmov)
        .subscribe(x => this.ibanco.codmov = x.codigo_Aux
          , error => this.ibanco.codmov = "")
    };
  }

}
