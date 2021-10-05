import { Component, ElementRef, Input, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { fromEvent } from "rxjs";
import { take, takeUntil } from "rxjs/operators";

@Component({
  selector: "rgp-error-message",
  templateUrl: "./error-message.component.html",
  styleUrls: ["./error-message.component.css"],
})
export class ErrorMessageComponent implements OnInit {
  protected errorMessage = "";
  controlStatus = false;
  @Input() control: FormControl;
  @Input() error: any;

  constructor(public elementRef: ElementRef) {}

  ngOnInit() {
    this.listenChangesForm();
    this.listenSubmitForm();
  }

  get statusError() {
    return (this.control ? this.control.invalid : false) && this.controlStatus;
  }

  listenChangesForm() {
    if (this.control) {
      this.control.valueChanges.pipe(take(1)).subscribe((val) => {
        if (val === null) {
          this.controlStatus = false;
        }
      });
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
      this.control &&
      this.control.invalid &&
      this.control.status !== "DISABLED"
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
