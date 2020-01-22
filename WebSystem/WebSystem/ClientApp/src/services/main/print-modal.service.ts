import { Injectable, Inject } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';

import { ModalFormsService } from './modal-forms.service';
import { RepomanService } from './repoman.service';
import { IParamRepo } from '../../models/main/paramrepo';
import { ReportComponent } from '../../app/pages/modal/Reportes/report/report.component';


@Injectable({
  providedIn: 'root'
})
export class PrintModalService {

  constructor(public dialog: MatDialog,
              public modalForms: ModalFormsService,
              public _repoman: RepomanService) { }
    
  printModal(tipo: string, numero: string, forma: string) {
    const dialogRef = this.dialog.open(ReportComponent, {
      width: '90%',
      height: '90%',
      data: { repoman: forma.trim().toUpperCase(), title: "Asiento Contable", tipo: tipo, numero: numero }
    });
  }

  printChequeEg(tipo: string, numero: string) {
    this.modalForms.messageboxOptions("Confirmar", "Desea imprimir cheques?")
      .subscribe(result => {
          if (!result) { return; }

            
            let parametros: IParamRepo[] = [];
            parametros.push({ parameter: "@tipo_asi", value: tipo });
            parametros.push({ parameter: "@asiento", value: numero });

            this._repoman.getRepoman("CHEQUES", parametros)
              .subscribe(xResul => {

                for (let x of xResul) {
                  let param2: IParamRepo[] = [];
                  parametros.push({ parameter: "@tipo_asi", value: x.tipo_asi });
                  parametros.push({ parameter: "@asiento", value: x.asiento });
                  parametros.push({ parameter: "@cuenta", value: x.codmov });
                                    
                    const dialogRef = this.dialog.open(ReportComponent, {
                      width: '90%',
                      height: '90%',
                      data: { repoman: x.formato.trim().toUpperCase(), title: "Cheque", tipo: tipo, numero: numero }
                  });

                  }
              }, error => console.error(error));        
      }); 
    
  }

}
