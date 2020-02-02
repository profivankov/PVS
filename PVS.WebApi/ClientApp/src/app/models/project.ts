import { Guid } from "guid-typescript";

export class Project {
    id?: Guid;
    userId?: Guid;
    projectName: string;
    description: string;
}