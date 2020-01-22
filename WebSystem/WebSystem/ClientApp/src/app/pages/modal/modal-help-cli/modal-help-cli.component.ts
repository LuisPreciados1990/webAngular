import { Component, OnInit, Inject } from '@angular/core';

import { Dp05a110Service } from '../../../../services/services.index';

import { IDp05a110 } from '../../../../models/Formas/COB/dp05a110';

import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';



@Component({
  selector: 'app-modal-help-cli',
  templateUrl: './modal-help-cli.component.html',
  styleUrls: ['./modal-help-cli.component.css']
})
export class ModalHelpCliComponent implements OnInit {
    
  public iClient: IDp05a110[];

  public yesNo: Boolean;
  public title = "";
  public content = "";
  public codCli = "";  

  constructor(public dialogRef: MatDialogRef<ModalHelpCliComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any,
              private cli: Dp05a110Service)
              {
                if (!data.title) { this.title = "Alerta.!"; }
                else { this.title = data.title }

                if (!data.content) { this.content = "Seguro?"; }
                else { this.content = data.content }

                this.yesNo = false;
              }

  ngOnInit() {
  }
  
  public buscarCliente(text:string): void {
      if (text.length >= 3) {              
        this.cli.GetClienteByNombre(text)
          .subscribe(x => this.iClient = x, error => console.error(error));
        } else {
        this.iClient = [];
      }

  }

  public onDobleClick(codigo:string): void {
    this.codCli = codigo;
    this.onNoClick();
  }

  onNoClick(): void {
    this.dialogRef.close(this.codCli);
  }


}
