import { Component, OnInit } from '@angular/core';

import { UsuariosService } from '../../../services/services.index';
import { DatePickerComponent } from '../../pages/modal/date-picker/date-picker.component';
import { ModalDialogComponent } from '../../pages/modal/modal-dialog/modal-dialog.component';
import { MatDialog } from '@angular/material';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  env = environment;

  constructor(private accountService: UsuariosService,
              public dialog: MatDialog) { }

  ngOnInit() {
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {

    const dialogRef = this.dialog.open(ModalDialogComponent, {
      width: '250px',
      data: { title: "Saliendo...", content: "Está seguro que desea salir?" }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result) { return; }
      this.accountService.logout();
    });    
  }

  changeDate() {
    const dialogRef = this.dialog.open(DatePickerComponent, {
      width: '375px',
      disableClose: true
    });

    //dialogRef.afterClosed().subscribe(result => {
    //  console.log
    //});
  }

  estaLogueado() {
    return this.accountService.estaLogueado();
  }

  verMenu() {
    alert("veo menu");
    //https://www.youtube.com/watch?v=Z8L5eRQiO70
  }

}
