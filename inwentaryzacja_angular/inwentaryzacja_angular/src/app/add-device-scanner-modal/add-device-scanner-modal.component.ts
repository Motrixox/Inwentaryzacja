import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DeviceType } from '../models/deviceType.model';
import { DeviceTypeService } from '../services/device-type.service';
import { DeviceService } from '../services/device.service';
import { Device } from '../models/device.model';
import { HttpErrorResponse } from '@angular/common/http';

declare var window: any;

@Component({
  selector: 'app-add-device-scanner-modal',
  templateUrl: './add-device-scanner-modal.component.html',
  styleUrls: ['./add-device-scanner-modal.component.css']
})
export class AddDeviceScannerModalComponent {
  @Input() code?: string = '';
  @Output() success = new EventEmitter<boolean>();
  @Output() successMessage = new EventEmitter<string>();
  @Output() failMessage = new EventEmitter<string>();
  formAddModal: any;
  deviceTypes: DeviceType[] = [];

  constructor(private deviceService: DeviceService, private deviceTypeService: DeviceTypeService){}

  ngOnInit(): void{
    this.getAllDeviceTypes();
    this.formAddModal = new window.bootstrap.Modal(
        document.getElementById("addDeviceScannerModal")
    );
  }

  getAllDeviceTypes(){
    this.deviceTypeService.getAllDeviceTypes()
        .subscribe({
          next: (deviceTypes) => {
            this.deviceTypes = deviceTypes;
          },
          error: (response) => {
            console.log(response);
          }
        });
  }

  onOpenModal() {
    this.formAddModal.show();
  }

  onCloseModal() {
    this.formAddModal.hide();
  }

  onSaveModal() {
    document.getElementById('submitBtn')?.click();
  }

  onAddDevice(addDeviceForm: NgForm){
    addDeviceForm.value.deviceTypeId = addDeviceForm.value.deviceTypeId;
    console.log("Add device form value: ", addDeviceForm.value);
    this.deviceService.addDevice(addDeviceForm.value).subscribe(
        (response: Device) => {
            this.success.next(true);
            this.successMessage.emit('Pomyślnie dodano urządzenie');
            addDeviceForm.reset();
            this.formAddModal.hide();
        },
        (error: HttpErrorResponse) => {
            console.log("Add device error: ", error.message);
            this.failMessage.next('Błąd przy dodawaniu urządzenia: ' + error.message);
            addDeviceForm.reset;
        }
    );
  }
}

