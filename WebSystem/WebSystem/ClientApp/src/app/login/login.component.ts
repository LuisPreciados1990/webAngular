import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UsuariosService } from '../../services/services.index';

import { Router } from '@angular/router';
import { IUsuarios } from '../../models/main/usuarios';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public msjError= "";
  public lErrorLogin = false;

  constructor(private fb: FormBuilder,
    private accountService: UsuariosService,
    private router: Router) { }

  formGroup: FormGroup;
  ngOnInit() {
    this.formGroup = this.fb.group({
      userId: '',
      userLog: '',
    });
  }

  loguearse() {
    let userInfo: IUsuarios = Object.assign({}, this.formGroup.value);
    //console.table(userInfo);
    this.accountService.login(userInfo).subscribe(token => this.recibirToken(token),
      error => this.manejarError(error));
  }

  registrarse() {
    let userInfo: IUsuarios = Object.assign({}, this.formGroup.value);
    this.accountService.create(userInfo).subscribe(token => this.recibirToken(token),
      error => this.manejarError(error));
  }

  recibirToken(token) {    
    localStorage.setItem('token', token.token);
    localStorage.setItem('tokenExpiration', token.expiration);
    //this.router.navigate(["fetch-data"]);

    let jwt = token.token

    let jwtData = jwt.split('.')[1]
    let decodedJwtJsonData = window.atob(jwtData)
    let decodedJwtData = JSON.parse(decodedJwtJsonData)

    let isAdmin = decodedJwtData.admin

    //console.log('jwtData: ' + jwtData)

    //console.log(decodedJwtJsonData)

    //console.log('decodedJwtData: ' + decodedJwtData)
    //console.log('Is admin: ' + isAdmin)
  }

  manejarError(error) {
    if (error && error.error) {
      this.msjError = error.error[""];
      this.lErrorLogin = true;      
    }
  }
}
