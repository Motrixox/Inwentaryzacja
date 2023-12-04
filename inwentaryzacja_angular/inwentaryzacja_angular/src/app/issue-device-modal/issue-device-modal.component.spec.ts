import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IssueDeviceModalComponent } from './issue-device-modal.component';

describe('IssueDeviceModalComponent', () => {
  let component: IssueDeviceModalComponent;
  let fixture: ComponentFixture<IssueDeviceModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [IssueDeviceModalComponent]
    });
    fixture = TestBed.createComponent(IssueDeviceModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
