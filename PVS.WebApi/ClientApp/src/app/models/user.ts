import { Guid } from "guid-typescript";

export class User {
    userId?: Guid;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
  }