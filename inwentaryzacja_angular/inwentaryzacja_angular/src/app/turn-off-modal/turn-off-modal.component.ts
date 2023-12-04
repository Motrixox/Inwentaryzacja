import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DeviceService } from '../services/device.service';
import { Device } from '../models/device.model';
import { HttpErrorResponse } from '@angular/common/http';

declare var window: any;

@Component({
  selector: 'app-turn-off-modal',
  templateUrl: './turn-off-modal.component.html',
  styleUrls: ['./turn-off-modal.component.css']
})
export class TurnOffModalComponent {
  @Input() deviceId?: string = '';
  @Output() success = new EventEmitter<boolean>();
  @Output() successMessage = new EventEmitter<string>();
  @Output() failMessage = new EventEmitter<string>();
  formModal: any;

  constructor(private deviceService: DeviceService){
  }

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
        document.getElementById("turnOffModal")
    );
  }

  openModal(){
    this.formModal.show();
  }
  onCloseModal(){
    this.formModal.hide();
  }

  clickSubmit(){
    console.log(this.deviceId);
    if(this.deviceId != undefined)
    {
      this.deviceService.TurnOff(this.deviceId).subscribe(
        (response: Device) => {
            console.log(response);
            this.success.next(true);
            this.successMessage.emit('Pomyślnie wyłączono urządzenie');
        },
        (error: HttpErrorResponse) => {
            console.log(error.message);
            this.failMessage.emit('Błąd podczas wyłączania urządzenia: ' + error.message);
        }
      );
      this.formModal.hide();
    }
  }
}
