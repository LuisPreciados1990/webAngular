import { Pipe, PipeTransform, WrappedValue } from '@angular/core';

@Pipe({
  name: 'cuenta'
})
export class CuentaPipe implements PipeTransform {

  transform(val: string): any {
    if (!val) return '';
    return WrappedValue.wrap(val.replace(/[^0-9.]/g, ''))
  }

}
