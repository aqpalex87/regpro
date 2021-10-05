import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'rgp-creation-request',
  templateUrl: './creation-request.component.html',
  styleUrls: ['./creation-request.component.css']
})
export class CreationRequestPage implements OnInit {

  public flagSearch: boolean = false
  public flagReadOnlyControls: boolean = false
  public titleMenu: string = "SOLICITUD DE CREACIÓN"
  public title: string = "REGISTRAR SOLICITUD DE CREACIÓN DE PROGRAMA"
  public flagCheckEdit: boolean = false
  public typeSend: number = 268

  constructor(
  ) { }

  ngOnInit() {
  }

}
