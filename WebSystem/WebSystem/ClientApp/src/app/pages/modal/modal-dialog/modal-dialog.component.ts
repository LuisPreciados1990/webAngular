import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-modal-dialog',
  templateUrl: './modal-dialog.component.html',
  styleUrls: ['./modal-dialog.component.css']
})
export class ModalDialogComponent implements OnInit {
  public yesNo    :Boolean;
  public title    ="";
  public content  ="";

  constructor(public dialogRef: MatDialogRef<ModalDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any)
              {
                if (!data.title) { this.title = "Alerta.!"; }
                else { this.title = data.title }

                if (!data.content) { this.content = "Seguro?"; }
                else { this.content = data.content }

                this.yesNo = false;
              }

  ngOnInit() {
  }

  onYesClick() {
    this.yesNo = true;
    this.dialogRef.close(this.yesNo);
  }

  onNoClick(): void {    
    this.dialogRef.close(this.yesNo);
  }

}
