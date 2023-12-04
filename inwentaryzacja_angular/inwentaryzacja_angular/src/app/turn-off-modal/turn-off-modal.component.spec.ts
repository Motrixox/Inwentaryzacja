import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurnOffModalComponent } from './turn-off-modal.component';

describe('TurnOffModalComponent', () => {
  let component: TurnOffModalComponent;
  let fixture: ComponentFixture<TurnOffModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TurnOffModalComponent]
    });
    fixture = TestBed.createComponent(TurnOffModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
