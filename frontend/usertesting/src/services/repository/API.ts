import { ErrorModel } from "../../models/api/ErrorModel";
import axios from 'axios';
import { APIRequestBase } from "../../models/api/request/base/APIRequestBase";

const baseUrl = 'https://localhost:44338/api';

interface APIResponse<T> {
    success: boolean;
    data?: T;
    error?: ErrorModel;
}

const API = {
    get: async <TResponse>(url: string, params?: any): Promise<APIResponse<TResponse>> => {
        try {
            const response = await axios.get<TResponse>(baseUrl + url, {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('accessToken')
                },
                params
            });
            return { success: true, data: response.data };
        } catch (error: any) {
            return { success: false, error: error.response?.data };
        }
    },

    post: async <TRequest extends APIRequestBase, TResponse>(
        url: string,
        data: TRequest,
        headers?: { [key: string]: string }
    ): Promise<APIResponse<TResponse>> => {
        try {
            const response = await axios.post<TResponse>(baseUrl + url, data, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + localStorage.getItem('accessToken'),
                    ...headers
                }
            });
            return { success: true, data: response.data };
        } catch (error: any) {
            return { success: false, error: error.response?.data };
        }
    },

};

export default API;