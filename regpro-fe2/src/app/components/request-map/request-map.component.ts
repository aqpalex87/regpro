import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'rgp-request-map',
  templateUrl: './request-map.component.html',
  styleUrls: ['./request-map.component.css']
})
export class RequestMapComponent implements OnInit, OnDestroy {

  public longitude : number = -11.261500;
  public latitude : number = -73.166528;

  private readonly zoom: number = 4.989;
  private map: L.Map;

  @ViewChild("mapContainer")
  mapContainer: ElementRef<HTMLInputElement>;

  constructor() { }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.initMap();
  }

  ngOnDestroy() {
  }

  private initMap(): void {
    this.map = L.map(this.mapContainer.nativeElement, {
      center: [this.longitude, this.latitude],
      zoom: this.zoom
    });
    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 18,
      minZoom: 0,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });

    tiles.addTo(this.map);
  }

  onMapReady(map:L.Map) {

  }

  changeLatitudeLongitude(longitude: number, latitude: number, zoom: number = this.zoom) {
    this.map.setView(new L.LatLng(longitude, latitude),zoom);
  }

  resetPosition() {
    this.map.setView(new L.LatLng(this.longitude, this.latitude), this.zoom);
  }
}
