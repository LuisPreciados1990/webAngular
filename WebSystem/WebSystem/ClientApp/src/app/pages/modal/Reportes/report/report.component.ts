import { Component, OnInit, Inject, ViewChild, ContentChildren, QueryList, ComponentFactoryResolver } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import {Input} from '@angular/core';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  public repoman  = "";
  public title    = "";
  public tipo     = "";
  public numero   = "";
    
  constructor(public dialogRef: MatDialogRef<ReportComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any)
  {
    if (!data.title) { this.title = "REPORTE"; }
    else { this.title = data.title }

    if (!data.repoman) { this.repoman = ""; }
    else { this.repoman = data.repoman }

    if (!data.tipo) { this.tipo = ""; }
    else { this.tipo = data.tipo }

    if (!data.numero) { this.numero = ""; }
    else { this.numero = data.numero }
  }    
  ngOnInit() {    
  }
  
  printPage() {
    //window.print();
    //https://stackblitz.com/github/IdanCo/angular-print-service?file=src%2Fapp%2Fprint.service.ts
    //https://stackblitz.com/edit/angular-printing-solution-example-3
    //https://www.youtube.com/watch?v=rZCMVGoLlVY
    //https://medium.com/@Idan_Co/angular-print-service-290651c721f9


    const printContent = document.getElementById("DIARIO");
    const WindowPrt = window.open('', '', 'left=0,top=0,width=900,height=900,toolbar=0,scrollbars=0,status=0');
    //const WindowPrt = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    WindowPrt.document.write(printContent.innerHTML);
    WindowPrt.document.close();
    WindowPrt.focus();
    WindowPrt.print();
    WindowPrt.close();

    //let printContents = document.getElementById("DIARIO").innerHTML;
    //let originalContents = document.body.innerHTML;

    //document.body.innerHTML = printContents;        
    //window.print();
    //document.body.innerHTML = originalContents;
    
  }
  
  ok(): void {
    this.dialogRef.close();
  }
}
