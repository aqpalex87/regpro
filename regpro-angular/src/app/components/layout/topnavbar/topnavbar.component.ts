import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

declare var jQuery: any;

import { smoothlyMenu } from '../../../app.helpers';
import { User } from '../../../models/user.model';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-topnavbar',
  templateUrl: './topnavbar.component.html',
  styleUrls: ['./topnavbar.component.css']
})
export class TopnavbarComponent implements OnInit {

  users: User[] = [];

  constructor(private userService: UserService) { }

  ngOnInit() {
    //this.userService.getAll().pipe(first()).subscribe(users => {
      //this.users = users;
    //});
  }

  toggleNavigation(): void {
    jQuery('body').toggleClass('mini-navbar');
    smoothlyMenu();
  }
}
