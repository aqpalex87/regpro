import { Component, OnInit, HostListener } from '@angular/core';
import { detectBody } from '../../app.helpers';

declare var jQuery: any;

@Component({
  selector: 'app-base-layout',
  templateUrl: './base-layout.component.html',
  styleUrls: ['./base-layout.component.css']
})
export class BaseLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    detectBody();
  }

  @HostListener('window:resize') onResize() {
    detectBody();
  }

}
