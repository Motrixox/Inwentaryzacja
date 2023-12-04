import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import { DeviceIssue } from "../models/deviceIssue.model";

@Injectable({
    providedIn: 'root'
})
export class IssuedDeviceService {
    private apiBaseUrl = environment.baseApiUrl;
    constructor(private http: HttpClient) {
    }

    addIssue(addDeviceIssueForm: DeviceIssue): Observable<DeviceIssue> {
        return this.http.post<DeviceIssue>(
            `${this.apiBaseUrl}/api/issueddevices`,
            addDeviceIssueForm,
            { withCredentials: true }
        );
    }

    ReturnIssue(editIssueForm: DeviceIssue): Observable<DeviceIssue> {
        return this.http.put<DeviceIssue>(
            `${this.apiBaseUrl}/api/issueddevices/return`,
            editIssueForm,
            { withCredentials: true }
        );
    }

    getLastIssueByDeviceId(id: string): Observable<DeviceIssue> {
        return this.http.get<DeviceIssue>(`${this.apiBaseUrl}/api/issueddevices/last/` + id,
        {withCredentials: true});
    }
}