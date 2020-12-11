import { FormGroup, FormArray } from '@angular/forms';

// Generic validator for Reactive forms
// Implemented as a class, not a service, so it can retain state for multiple forms.
export class GenericValidator {

  // Provide the set of valid validation messages
  // Stucture:
  // controlName1: {
  //     validationRuleName1: 'Validation Message.',
  //     validationRuleName2: 'Validation Message.'
  // },
  // controlName2: {
  //     validationRuleName1: 'Validation Message.',
  //     validationRuleName2: 'Validation Message.'
  // }

  public validationMessages: { [key: string]: { [key: string]: string } };

  constructor(messages: { [key: string]: { [key: string]: string } }) {
    this.validationMessages = messages;
  }

  // Processes each control within a FormGroup
  // And returns a set of validation messages to display
  // Structure
  // controlName1: 'Validation Message.',
  // controlName2: 'Validation Message.'
  processMessages(container: FormGroup, parentKey: string = null, showInvalid: boolean = false): { [key: string]: string } {
    const messages = {};
    for (const controlKey in container.controls) {
      if (container.controls.hasOwnProperty(controlKey)) {
        const c = container.controls[controlKey];
        // If it is a FormGroup, process its child controls.
        if (c instanceof FormArray) {
          let index = -1;
          c.controls.forEach(x => {
            index += 1;
            const cx = <FormGroup>x;
            const key = (parentKey ? `${parentKey}_${controlKey}_${index}` : `${controlKey}_${index}`);
            const childMessages = this.processMessages(cx, key, showInvalid);
            Object.assign(messages, childMessages);
          });
        } else {
          if (c instanceof FormGroup) {
            const childMessages = this.processMessages(c, controlKey, showInvalid);
            Object.assign(messages, childMessages);
          } else {
            // Only validate if there are validation messages for the control
            const key = (parentKey ? `${parentKey}_${controlKey}` : controlKey);
            if (this.validationMessages[key]) {
              messages[key] = '';
              const invalid = showInvalid ? c.errors : (c.dirty || c.touched) && c.errors;
              if (invalid) {
                Object.keys(c.errors).map(messageKey => {
                  if (this.validationMessages[key][messageKey]) {
                    messages[key] += this.validationMessages[key][messageKey] + ' ';
                  }
                });
              }
            }
          }
        }
      }
    }
    return messages;
  }

  getErrorCount(container: FormGroup): number {
    let errorCount = 0;
    for (const controlKey in container.controls) {
      if (container.controls.hasOwnProperty(controlKey)) {
        if (container.controls[controlKey].errors) {
          errorCount += Object.keys(container.controls[controlKey].errors).length;
          console.log(errorCount);
        }
      }
    }
    return errorCount;
  }


}
