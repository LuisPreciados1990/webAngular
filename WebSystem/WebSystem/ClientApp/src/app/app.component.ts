import { Component, Input} from '@angular/core';
import { UsuariosService } from '../services/services.index';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @Input() verMenu: boolean = true;
  constructor(private accountService: UsuariosService) { }  

  logout() {
    this.accountService.logout();    
  }
  estaLogueado() {
    return this.accountService.estaLogueado();
  }
}
