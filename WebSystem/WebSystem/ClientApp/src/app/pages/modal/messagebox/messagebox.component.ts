import { Component, OnInit,Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-messagebox',
  templateUrl: './messagebox.component.html',
  styleUrls: ['./messagebox.component.css']
})
export class MessageboxComponent implements OnInit {  
  public title = "";
  public content = "";

  constructor(public dialogRef: MatDialogRef<MessageboxComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    if (!data.title) { this.title = "Mensaje"; }
    else { this.title = data.title }

    if (!data.content) { this.content = "Mensaje..!"; }
    else { this.content = data.content }        
  }

  ngOnInit() {
  }
  ok(): void {
    this.dialogRef.close();
  }

}
