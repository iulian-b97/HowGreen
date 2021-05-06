import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProsumatorComponent } from './prosumator.component';

describe('ProsumatorComponent', () => {
  let component: ProsumatorComponent;
  let fixture: ComponentFixture<ProsumatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProsumatorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProsumatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
