import { Component, OnInit, Input } from '@angular/core';
import { FormArray, FormBuilder, FormControl, Validators } from '@angular/forms';
import { BaseComponent } from '../../shared/baseComponent';
import { GenericValidator } from 'src/app/shared/generic-validator';
import { BookService } from 'src/app/services/Nm.service';
import { UUID } from 'angular2-uuid';


@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html'
})
export class BookingComponent extends BaseComponent implements OnInit {

  @Input() data: any;
  bookings = [];

  get toppings() {
    return this.form.controls.toppings as FormArray;
  }

  constructor(
    public bx: BookService,
    private fb: FormBuilder) {

    super();

    const validationMessages = {
      tea: { required: 'Tea is required' },
      flavour: { required: 'Flavour is required.' },
      topping: { required: 'Please select a topping.' }
    };

    this.validator = new GenericValidator(validationMessages);
  }

  ngOnInit() {

    this.form = this.fb.group({
      tea: [null, [Validators.required]],
      flavour: [null, [Validators.required]],
      toppings: new FormArray([]),
      size: ['M']
    });

    this.bx.GetBookingOptions().subscribe(data => {
      this.data = data;
      this.data.toppings?.forEach(() => this.toppings.push(new FormControl(false)));
    });

  }

  delete(booking: any) {
    this.bookings = this.bookings.filter(t => t.id !== booking.id);
  }

  edit(booking: any) {
    this.form.patchValue({
      tea: booking.tea,
      flavour: booking.flavour,
      toppings: booking.toppings,
      size: booking.size
    });
  }

  add() {
    if (this.validate(this.form)) {
      const vals = this.form.value;
      const tea = this.data.teas.filter(t => t.id === vals.tea)[0];
      const flavour = this.data.flavours.filter(t => t.id === vals.flavour)[0];
      let toppingCount = 0;
      vals.toppings.filter(t => {
        if (t === true) { toppingCount++; }
      });
      this.bookings.push({
        id: UUID.UUID(),
        teaId: tea.id,
        teaName: tea.name,
        flavourId: flavour.id,
        flavourName: flavour.name,
        toppingsIds: vals.toppings,
        toppingCount: toppingCount,
        size: vals.size
      });
    }
  }

}
