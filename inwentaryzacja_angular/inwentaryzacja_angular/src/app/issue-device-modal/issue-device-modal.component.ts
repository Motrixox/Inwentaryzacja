import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';
import { IssuedDeviceService } from '../services/issuedDevice.service';
import { DeviceIssue } from '../models/deviceIssue.model';
import { HttpErrorResponse } from '@angular/common/http';

declare var window: any;

@Component({
  selector: 'app-issue-device-modal',
  templateUrl: './issue-device-modal.component.html',
  styleUrls: ['./issue-device-modal.component.css']
})
export class IssueDeviceModalComponent implements OnInit {
  @Input() deviceId?: string ='';
  @Input() place?: string ='';
  @Input() serialNumber?: string = '';
  @Output() success = new EventEmitter<boolean>();
  @Output() successMessage = new EventEmitter<string>();
  @Output() failMessage = new EventEmitter<string>();

  employeeId: string = '';
  now: string;
  formModal: any;

  constructor(private issuedDeviceService: IssuedDeviceService){
    this.now = (new Date()).toISOString().substring(0,10);
  }

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
        document.getElementById("issueDeviceModal")
    );
  }

  setEmployeeId(id: string)
  {
    this.employeeId = id;
  }

  openModal(){
    this.formModal.show();
  }
  onCloseModal(){
    this.formModal.hide();
  }

  clickSubmit(){
    document.getElementById('issueSubmitButton')?.click();
  }

  onAddDeviceIssue(addDeviceIssue: NgForm){
      addDeviceIssue.value.employeeId = this.employeeId;
      addDeviceIssue.value.DateOfIssue = new Date(addDeviceIssue.value.DateOfIssue);
      console.log(addDeviceIssue.value);

      this.issuedDeviceService.addIssue(addDeviceIssue.value).subscribe(
        (response: DeviceIssue) => {
            console.log(response);
            addDeviceIssue.reset();
            this.formModal.hide();
            this.success.next(true);
            this.successMessage.emit('Pomyślnie wydano urządzenie');
        },
        (error: HttpErrorResponse) => {
            console.log(error.message);
            this.failMessage.emit('Błąd podczas wydawania urządzenia: ' + error.message);
            addDeviceIssue.reset;
        }
    );
  }
}
