export interface Employee{
    id: string;
    firstName: string;
    lastName: string;
    position: string;
    devices: Device[] | null;
}

export interface Device{
    id: string;
    type: string;
    description: string;
}
