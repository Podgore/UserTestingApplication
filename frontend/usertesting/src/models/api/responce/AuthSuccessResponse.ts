import { APIResponseBase } from "./base/APIResponseBase";

export interface AuthSuccessResponse extends APIResponseBase {
    accessToken: string;
}