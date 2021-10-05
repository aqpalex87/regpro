import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'rgp-closing-request',
  templateUrl: './closing-request.component.html',
  styleUrls: ['./closing-request.component.css']
})
export class ClosingRequestPage implements OnInit {

  public flagSearch: boolean = true
  public flagReadOnlyControls: boolean = true
  public titleMenu: string = "SOLICITUD DE CIERRE"
  public title: string = "REGISTRAR SOLICITUD DE CIERRE DE PROGRAMA"
  public flagCheckEdit: boolean = false
  public typeSend: number = 271

  constructor(
  ) { }

  ngOnInit() {
  }

}
