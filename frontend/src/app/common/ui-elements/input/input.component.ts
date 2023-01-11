import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss'],
  providers: [{
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputComponent),
      multi: true
    }]
})
export class InputComponent implements ControlValueAccessor {
  @Input() public type? : string;
  @Input() public placeholder? : string;

  public val? : string;
  public disabled = false;

  public onChange: any = () => { };
  public onTouched: any = () => { };

  set value(val : string) {
    this.val = val;
    this.onChange(val);
    this.onTouched(val);
  }

  writeValue(value: string) : void {
    this.val = value;
  }

  registerOnChange(fn : any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn : any): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled : boolean): void {
    this.disabled = isDisabled;
  }
}
