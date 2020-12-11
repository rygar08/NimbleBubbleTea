import { AfterViewInit, ViewChildren, ElementRef, Component } from '@angular/core';
import { FormControlName, FormGroup } from '@angular/forms';
import { Observable, merge, fromEvent } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { GenericValidator } from './generic-validator';

@Component({ template: '' })
export class BaseComponent implements AfterViewInit {

  public form: FormGroup;
  public view: string;
  public showAllErrors: boolean;
  public errorMessage: string;
  public displayMessage: { [key: string]: string } = {};
  public validator: GenericValidator;
  public scrollOnValidation = true;

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];


  constructor() {
    this.validator = new GenericValidator({});
  }


  ngAfterViewInit(): void {
    // Watch for the blur event from any input element on the form.
    const controlBlurs: Observable<any>[] = this.formInputElements.map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(this.form.valueChanges, ...controlBlurs).pipe(debounceTime(800)).subscribe(value => {
      this.displayMessage = this.validator.processMessages(this.form, null, this.showAllErrors);
    });

    merge(this.form.valueChanges, ...controlBlurs).subscribe(value => {
      if (this.form.valid) { this.errorMessage = null; }
    });

  }

  public validate(fg: FormGroup): boolean {
    if (fg.valid) {
      this.showAllErrors = false;
      return true;
    }

    this.showAllErrors = true;
    this.displayMessage = this.validator.processMessages(fg, null, this.showAllErrors);
    this.scrollToError();
    return false;
  }

  scrollToError(): void {
    if (this.scrollOnValidation) {
      setTimeout(() => {

        const el = document.querySelector('.is-invalid, .invalid-feedback');
        if (el) {
          const offset = el.getBoundingClientRect();
          window.scrollBy({
            top: offset.top - 150,
            left: 0,
            behavior: 'smooth'
          });
          //   el.scrollIntoView({ behavior: 'smooth' });
        }
      }, 100);
    }

  }



}
