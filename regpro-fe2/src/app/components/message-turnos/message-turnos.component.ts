import { Component, OnInit , Inject, EventEmitter} from '@angular/core';
//import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-message-turnos-dialog',
  templateUrl: './message-turnos.component.html',
  styleUrls: ['./message-turnos.component.scss']
})
export class MessageTurnosDialogComponent implements OnInit {
  onAceptar = new EventEmitter<any>();
  onCancelar = new EventEmitter<any>();
  public title = null;
  public message = null;
  public state = null;
  public isCancel = true;
  public isConfirm = true;
  public url = "/medic/plans";

  constructor(
      //@Inject(MAT_DIALOG_DATA) public data: any,
      //public dialogRef: MatDialogRef<MessageTurnosDialogComponent>
      ) {
      //this.title = data.title;
      //this.message = data.message;
      //this.state = data.state;
      //this.isCancel = data.isCancel;
      //this.isConfirm = data.isConfirm;
   }

  ngOnInit(): void {
  }

  onCancel(): void {
    this.onCancelar.emit();
    //this.dialogRef.close(true);
  }

  onConfirm(): void {
    this.onAceptar.emit({url:this.url});
    //this.dialogRef.close(true);
  }  
}
