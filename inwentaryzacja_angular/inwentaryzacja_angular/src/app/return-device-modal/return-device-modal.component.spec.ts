import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnDeviceModalComponent } from './return-device-modal.component';

describe('ReturnDeviceModalComponent', () => {
  let component: ReturnDeviceModalComponent;
  let fixture: ComponentFixture<ReturnDeviceModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReturnDeviceModalComponent]
    });
    fixture = TestBed.createComponent(ReturnDeviceModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
