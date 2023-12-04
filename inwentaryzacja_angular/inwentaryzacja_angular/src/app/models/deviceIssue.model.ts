export interface DeviceIssue{
    id:string;
    deviceId:string;
    device: Device;
    employeeId:string;
    employee: Employee;
    dateOfIssue:Date;
    dateOfReturn:Date;
    notes?:string;
    place?:string;
}

export interface Device{
    serialNumber: string;
}

export interface Employee{
    firstName: string;
    lastName: string;
}