import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DeviceService } from '../services/device.service';
import { Device } from '../models/device.model';
import { HttpErrorResponse } from '@angular/common/http';

declare var window: any;

@Component({
  selector: 'app-inventory-device',
  templateUrl: './inventory-device.component.html',
  styleUrls: ['./inventory-device.component.css']
})
export class InventoryDeviceComponent {
  @Input() deviceId?: string = '';
  @Input() status?: boolean;
  @Output() success = new EventEmitter<boolean>();
  @Output() successMessage = new EventEmitter<string>();
  @Output() failMessage = new EventEmitter<string>();
  formModal: any;

  constructor(private deviceService: DeviceService){
  }

  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
        document.getElementById("inventoryDeviceModal")
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
      let array: string[]= [this.deviceId];
      this.deviceService.ChangeGroupStatus(array).subscribe(
        (response: Device) => {
            console.log(response);
            this.successMessage.emit('Pomyślnie zmieniono stan inwentaryzacji');
            this.success.next(true);
        },
        (error: HttpErrorResponse) => {
            console.log(error.message);
            this.successMessage.emit('Błąd podczas zmiany stanu inwentaryzacji: ' + error.message);
        }
    );
      this.formModal.hide();
    }
  }
}
