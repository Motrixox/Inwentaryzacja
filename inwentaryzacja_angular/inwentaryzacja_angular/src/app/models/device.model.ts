import { DeviceType } from "./deviceType.model";

export interface Device{
    id: string;
    code: string;
    serialNumber: string;
    description: string;
    employeeId: string;
    deviceType: DeviceType;
    employee: Employee;
    isConfirmed: boolean;
    status: Status;
    place: string;
    checked?: boolean;
}

interface Employee{
    id: string;
    firstName: string;
    lastName: string;
    position: string;
}

export enum Status
{
    Niewydany = 1,
    Wydany = 2,
    Wyłączony = 3
}