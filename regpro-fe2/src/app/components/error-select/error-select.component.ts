import { Component, ElementRef, Input, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { fromEvent } from "rxjs";
import { take, takeUntil } from "rxjs/operators";

@Component({
  selector: "rgp-error-select",
  templateUrl: "./error-select.component.html",
  styleUrls: ["./error-select.component.css"],
})
export class ErrorSelectMessageComponent implements OnInit {
  protected errorMessage = "";
  controlStatus = false;
  @Input() control: boolean;
  @Input() error: any;

  constructor(public elementRef: ElementRef) {}

  ngOnInit() {
    this.listenChangesForm();
    this.listenSubmitForm();
  }

  get statusError() {
    return (this.control ? true : false) && this.controlStatus;
  }

  listenChangesForm() {
    if (this.control) {
      this.controlStatus = false;
    }
  }

  listenSubmitForm() {
    const form = this.elementRef.nativeElement.closest("form");

    if (form) {
      fromEvent(form, "submit")
        .pipe(take(1))
        .subscribe(() => {
          this.showErrorForm();
        });
    }
  }

  showErrorForm() {
    if (
      this.control
    ) {
      this.controlStatus = true;
      if (this.error && typeof this.error === "string") {
        this.errorMessage = this.error;
      }
    } else {
      this.controlStatus = false;
    }
  }
}
