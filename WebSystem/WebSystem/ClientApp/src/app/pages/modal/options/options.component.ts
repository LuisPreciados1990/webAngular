import { Component, OnInit, Inject, ViewChild, ContentChildren, QueryList, ComponentFactoryResolver } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Input } from '@angular/core';


@Component({
  selector: 'app-options',
  templateUrl: './options.component.html',
  styleUrls: ['./options.component.css']
})
export class OptionsComponent implements OnInit {

  public option1 = "Imprimir"
  public option2 = "Modificar"
  public option3 = "Anular"
  public option4 = "Eliminar"

  public disable1 = true;
  public disable2 = true;
  public disable3 = true;
  public disable4 = true;

  constructor(public dialogRef: MatDialogRef<OptionsComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any) {}

  ngOnInit() {    
  }

  opciones(opcion:number) {
    this.dialogRef.close(opcion);
  }

}
