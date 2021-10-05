import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { first,map, takeUntil } from 'rxjs/operators';
import 'jquery-slimscroll';
import { Subject } from 'rxjs';
import { NgxPermissionsService, NgxRolesService } from 'ngx-permissions';

declare var jQuery: any;

import { Weather } from '../../../models/weather.model';
import { WeatherService } from '../../../services/weather.service';

@Component({
  selector: 'app-side-navigation',
  templateUrl: './side-navigation.component.html',
  styleUrls: ['./side-navigation.component.css']
})
export class SideNavigationComponent implements OnInit {

  roles = ['Guest', 'Admin', 'President', 'PrimeMinister', 'PresidentAndPrimeMinister'];
  permissions$ = this.ps.permissions$;
  roles$ = this.rs.roles$;

  rolePermissions = {
    Guest: ['GUEST'],
    Admin: ['ADMIN'],
    President: ['PRESIDENT'],
    PrimeMinister: ['PRIME-MINISTER'],
    PresidentAndPrimeMinister: ['PRIME-MINISTER', 'PRESIDENT'],
  };

  unsubscribe$ = new Subject();

  hasRole$ = this.roles$.pipe(
    map(permissions => Object.keys(permissions).length > 0),
    takeUntil(this.unsubscribe$),
  );

  geolocationPosition: any;
  weather: Weather[] = [];

  constructor(private router: Router, private weatherService: WeatherService,private ps: NgxPermissionsService, private rs: NgxRolesService) { }

  ngOnInit() {
    const guest = 'Guest';
    const permissions = this.rolePermissions[guest];
    console.log(permissions);
    this.ps.loadPermissions(permissions);
    this.rs.addRole(guest, permissions);
    if (window.navigator && window.navigator.geolocation) {
      window.navigator.geolocation.getCurrentPosition(
        position => {
          this.geolocationPosition = position;
          console.log(position);
        },
        error => {
          switch (error.code) {
            case 1:
              console.log('Permission Denied');
              break;
            case 2:
              console.log('Position Unavailable');
              break;
            case 3:
              console.log('Timeout');
              break;
          }
        }
      );
    }

    // this.weatherService.getCurrentWeather().pipe(first()).subscribe(weather => {
    //   this.weather = weather;
    // });
  }

  ngAfterViewInit() {
    jQuery('#side-menu').metisMenu();

    if (jQuery('body').hasClass('fixed-sidebar')) {
      jQuery('.sidebar-collapse').slimscroll({
        height: '100%'
      });
    }
    
  }
  activeRoute(routename: string): boolean {
    return this.router.url.indexOf(routename) > -1;
  }

}
