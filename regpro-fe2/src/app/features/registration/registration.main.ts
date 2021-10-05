import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "rgp-registration",
  templateUrl: "./registration.main.html",
})
export class RegistrationMain implements OnInit {
  constructor(private router: Router) {}

  ngOnInit(): void {
    console.log("router", this.router.url);
  }
}
