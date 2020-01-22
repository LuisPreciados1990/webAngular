import { Component, OnInit, Input } from '@angular/core';

import { RepomanService } from '../../../../../services/services.index';

import { IParamRepo } from '../../../../../models/main/paramrepo';

import { environment } from '../../../../../environments/environment';

@Component({
  selector: 'app-diario',
  templateUrl: './diario.component.html',
  styleUrls: ['./diario.component.css']
})
export class DiarioComponent implements OnInit {

  public env = environment;
  public fechaAsi: Date;
  public concepto: string;
  public totalDebe: number;
  public totalHaber: number;

  @Input() param: any;
  public tb: any[];

  constructor(public _repoman: RepomanService) { }

  ngOnInit() {

    //Agregamos los parametros necesarios
    let parametros: IParamRepo[] = [];
    parametros.push({ parameter: "@tipo_asi", value: this.param.tipo });
    parametros.push({ parameter: "@asiento", value: this.param.numero });

    this._repoman.getRepoman(this.param.repoman, parametros)
      .subscribe(x => {
        this.tb = x;
        this.fechaAsi = this.tb[0].fecha_asi;
        this.concepto = this.tb[0].desc_asi;
        this.totalDebe = this.tb[0].debitos;
        this.totalHaber = this.tb[0].creditos;
      }, error => console.error(error));
  }

}
