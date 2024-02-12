import { ErrorModel } from "../models/api/ErrorModel";
import { AuthSuccessResponse } from "../models/api/responce/AuthSuccessResponse";
import API from "./repository/API";

const AuthRepository = {
    signIn: async (email: string): Promise<ErrorModel | undefined> => {
        const response = await API.post<{ email: string }, AuthSuccessResponse>('/auth/sign-in', { email });
        console.log(response);
        if (response.success) {
            const tokens = response.data as AuthSuccessResponse;
            localStorage.setItem('accessToken', tokens.accessToken ?? '');

            return undefined;
        }

        return response.error;
    }
}

export default AuthRepository;