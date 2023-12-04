import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IssuedDeviceService } from '../services/issuedDevice.service';
import { DeviceIssue } from '../models/deviceIssue.model';
import { HttpErrorResponse } from '@angular/common/http';
import { NgForm } from '@angular/forms';

declare var window: any;

@Component({
  selector: 'app-return-device-modal',
  templateUrl: './return-device-modal.component.html',
  styleUrls: ['./return-device-modal.component.css']
})
export class ReturnDeviceModalComponent {

  @Input() deviceId?: string = "";
  @Input() place?: string = "";
  @Output() success = new EventEmitter<boolean>();
  @Output() successMessage = new EventEmitter<string>();
  @Output() failMessage = new EventEmitter<string>();

  employeeId: string = ''
  DateOfIssueString: string = ''
  now: string;
  formModal: any;
  //issuedDevice: DeviceIssue = {id: 1, deviceId: 1, employeeId: 1, dateOfIssue: new Date, dateOfReturn: new Date};
  issuedDevice: DeviceIssue | undefined;

  constructor(private issuedDeviceService: IssuedDeviceService){
    this.now = (new Date()).toISOString().substring(0,10);
  }

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
        document.getElementById("returnDeviceModal")
    );
  }

  openModal(){
    this.formModal.show();
    if(this.deviceId != undefined)
    {
      this.issuedDeviceService.getLastIssueByDeviceId(this.deviceId.toString()).subscribe(
        {
          next: (issue) => {
            this.issuedDevice = issue;
            this.DateOfIssueString = this.issuedDevice.dateOfIssue.toString().substring(0,10);
            console.log(this.deviceId);
            console.log(this.issuedDevice);
          },
          error: (response) => {
            console.log(response);
          }
        }
      );
    }
  }
  onCloseModal(){
    this.formModal.hide();
  }

  clickSubmit(){
    document.getElementById('returnSubmitButton')?.click();
  }

  onAddDeviceReturn(addDeviceReturn: NgForm){
    addDeviceReturn.value.DateOfIssue = new Date(addDeviceReturn.value.DateOfIssue);
    addDeviceReturn.value.DateOfReturn = new Date(addDeviceReturn.value.DateOfReturn);
    console.log(addDeviceReturn.value);

    this.issuedDeviceService.ReturnIssue(addDeviceReturn.value).subscribe(
      (response: DeviceIssue) => {
          console.log(response);
          //addDeviceReturn.reset();
          this.formModal.hide();
          this.success.next(true);
          this.successMessage.emit('Pomyślnie zwrócono urządzenie');
      },
      (error: HttpErrorResponse) => {
          console.log(error.message);
          this.failMessage.emit('Błąd podczas zwracania urządzenia: ' + error.message);
          //addDeviceReturn.reset;
      }
    );
  }
}
