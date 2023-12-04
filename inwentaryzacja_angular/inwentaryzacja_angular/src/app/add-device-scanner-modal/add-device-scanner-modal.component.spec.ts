import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDeviceScannerModalComponent } from './add-device-scanner-modal.component';

describe('AddDeviceScannerModalComponent', () => {
  let component: AddDeviceScannerModalComponent;
  let fixture: ComponentFixture<AddDeviceScannerModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddDeviceScannerModalComponent]
    });
    fixture = TestBed.createComponent(AddDeviceScannerModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
