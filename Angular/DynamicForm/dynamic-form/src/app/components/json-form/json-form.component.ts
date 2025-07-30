import { CommonModule } from '@angular/common';
import {
  ChangeDetectionStrategy,
  Component,
  Input,
  OnChanges,
  SimpleChanges,
} from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

export interface JsonFormData {
  controls: JsonFormControls[];
}

interface JsonFormControls {
  name: string;
  label: string;
  value: string;
  type: string;
  validators: JsonFormValidators;
  options?: JsonFormControlOptions;
  required: boolean;
  disabled?: boolean;
  placeholder?: string;
}

interface JsonFormValidators {
  min?: number;
  max?: number;
  required?: boolean;
  requiredTrue?: boolean;
  email?: boolean;
  minLength?: boolean;
  maxLength?: boolean;
  pattern?: string;
  nullValidator?: boolean;
}

interface JsonFormControlOptions {
  min: string;
  max: string;
  step: string;
  icon: string;
}

@Component({
  selector: 'app-json-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './json-form.component.html',
  styleUrl: './json-form.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class JsonFormComponent implements OnChanges {
  @Input() jsonFormData: JsonFormData;

  myForm: FormGroup;

  constructor(private fb: FormBuilder) {
    // Initialize jsonData with an empty object or a default value
    this.jsonFormData = { controls: [] };
    this.myForm = this.fb.group({});
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (!changes['jsonFormData'].firstChange) {
      // Handle changes to jsonFormData if needed
      this.createForm(this.jsonFormData.controls);
    }
  }

  createForm(controls: JsonFormControls[]) {
    for (const control of controls) {
      const validators = this.getValidators(control.validators);
      this.myForm.addControl(
        control.name,
        this.fb.control(control.value, validators)
      );
    }
  }

  getValidators(validators: JsonFormValidators): any[] {
    const formValidators = [];
    for (const [key, value] of Object.entries(validators)) {
      if (validators.hasOwnProperty(key)) {
        switch (key) {
          case 'required':
            if (value) formValidators.push(Validators.required);
            break;
          case 'min':
            formValidators.push(Validators.min(value));
            break;
          case 'max':
            formValidators.push(Validators.max(value));
            break;
          case 'email':
            if (value) formValidators.push(Validators.email);
            break;
          case 'minLength':
            formValidators.push(Validators.minLength(value));
            break;
          case 'maxLength':
            formValidators.push(Validators.maxLength(value));
            break;
          case 'pattern':
            formValidators.push(Validators.pattern(value));
            break;
          case 'requiredTrue':
            if (value) {
              formValidators.push(Validators.requiredTrue);
            }
            break;
          case 'nullValidator':
            if (value) {
              formValidators.push(Validators.nullValidator);
            }
            break;

          default:
            break;
        }
      }
    }

    return formValidators;
  }

  onSubmit() {
    console.log('Form valid!', this.myForm.valid);
    console.log('Form values', this.myForm.value);
  }
}
