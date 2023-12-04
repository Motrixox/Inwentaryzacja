import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {Device} from "../models/device.model";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import { DeviceSend } from "../models/deviceSend.model";

@Injectable({
    providedIn: 'root'
})
export class DeviceService {
    private apiBaseUrl = environment.baseApiUrl;
    constructor(private http: HttpClient) {
    }
   getallDevices(): Observable<Device[]> {
        return this.http.get<Device[]>(
            `${this.apiBaseUrl}/api/Devices`,
            { withCredentials: true }
            );
    }
    addDevice(addDeviceForm: Device): Observable<Device> {
        return this.http.post<Device>(
            `${this.apiBaseUrl}/api/Devices`,
            addDeviceForm,
            { withCredentials: true }
        );
    }
    editDevice(editDeviceForm: Device): Observable<Device>{
        return this.http.put<Device>(
            `${this.apiBaseUrl}/api/Devices`,
            editDeviceForm,
            {withCredentials: true}
        )
    }

    getDeviceByCode(code: string): Observable<Device>{
        return this.http.get<Device>(`${this.apiBaseUrl}/api/Devices/code/` + code,
        {withCredentials: true});
      }

    ChangeGroupStatus(ids: string[]): Observable<Device> {
        return this.http.put<Device>(`${this.apiBaseUrl}/api/Devices/Status`,
        ids,
        {withCredentials: true});
    }

    TurnOff(id: string): Observable<Device> {
        return this.http.put<Device>(`${this.apiBaseUrl}/api/Devices/TurnOff/` + id,
        {withCredentials: true});
    }
}