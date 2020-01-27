import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormrootComponent } from './formroot.component';

describe('FormrootComponent', () => {
  let component: FormrootComponent;
  let fixture: ComponentFixture<FormrootComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormrootComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormrootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
