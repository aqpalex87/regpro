import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'rgp-renovation-request',
  templateUrl: './renovation-request.component.html',
  styleUrls: ['./renovation-request.component.css']
})
export class RenovationRequestPage implements OnInit {

  public flagSearch: boolean = true
  public flagReadOnlyControls: boolean = true
  public titleMenu: string = "SOLICITUD DE RENOVACIÓN"
  public title: string = "REGISTRAR SOLICITUD DE RENOVACIÓN DE PROGRAMA"
  public flagCheckEdit: boolean = false
  public typeSend: number = 270

  constructor(
  ) { }

  ngOnInit() {
  }

}
