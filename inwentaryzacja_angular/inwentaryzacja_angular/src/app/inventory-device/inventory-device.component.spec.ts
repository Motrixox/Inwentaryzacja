import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InventoryDeviceComponent } from './inventory-device.component';

describe('InventoryDeviceComponent', () => {
  let component: InventoryDeviceComponent;
  let fixture: ComponentFixture<InventoryDeviceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InventoryDeviceComponent]
    });
    fixture = TestBed.createComponent(InventoryDeviceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
