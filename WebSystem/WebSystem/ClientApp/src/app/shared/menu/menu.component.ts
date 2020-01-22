import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

import { UsuariosService, GestionesService, ProgramasService } from '../../../services/services.index';

import { IGestion } from '../../../models/main/gestiones';
import { IPrograma } from '../../../models/main/programas';
import { IOpcion } from '../../../models/main/opciones';

import { AppComponent } from '../../app.component';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit{
    
  //public menuWidth = 19;  
  public isHide = false;
  public conteLeft = 19;
  public contewidth = 81;
     
  @Input() nameMenu: string;  
    
  public gesti: IGestion[];
  public prg: IPrograma[];
  public opciones: IOpcion[];
  
  constructor(private accountService: UsuariosService,
    private gestiones: GestionesService,
    private programa:ProgramasService,
    private router: Router,
    public appComponent: AppComponent)
    {}    

  ngOnInit() {
    this.cargarData();
    //this.openTab("Inicio", this.inicial, this.inicial)
    this.cargarOpcion();
    this.cargarPrograma()
    //console.log(this.prg);
  }
  
  estaLogueado() {
    return this.accountService.estaLogueado();
  }

  hideOrShow(Hide:boolean) {
    if (Hide) {
      //this.menuWidth = 0;
      this.conteLeft = 3;
      this.contewidth = 97;
    }
    else {
      //this.menuWidth = 19;
      this.conteLeft = 19;
      this.contewidth = 81;
    }    
    this.isHide = Hide;
  }

  cargarOpcion() {
    this.opciones = [{ Codigo:'MAN', Nombre: 'Mantenimiento' },
      { Codigo: 'TRA',Nombre: 'Transaccion' },
      { Codigo: 'INF',Nombre: 'Informe' }
    ];
  }

  cargarData() {
    this.gestiones.getGestiones()
      .subscribe(gestionesDesdeWS => this.gesti = gestionesDesdeWS,
      error => console.error(error));    
  }

  cargarPrograma() {    
    this.programa.getAllTask()
      .subscribe(prgDesdeWS => {
        this.prg = prgDesdeWS;

      },
        error => console.error(error));    
  }

  openTab(title: string, template) {        
    //this.tabsComponent.openTab(title, template,{},true);    
    this.router.navigate(['/' + template]);
  }

}
