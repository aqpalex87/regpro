import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'rgp-modification-request',
  templateUrl: './modification-request.component.html',
  styleUrls: ['./modification-request.component.css']
})
export class ModificationRequestPage implements OnInit {

  public flagSearch: boolean = true
  public flagReadOnlyControls: boolean = true
  public titleMenu: string = "SOLICITUD DE MODIFICACIÓN"
  public title: string = "REGISTRAR SOLICITUD DE MODIFICACIÓN DE PROGRAMA"
  public flagCheckEdit: boolean = true
  public typeSend: number = 269

  constructor(
  ) { }

  ngOnInit() {
  }

}
