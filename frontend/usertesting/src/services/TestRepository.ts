import { AnswersRequest } from "../models/api/request/AnswersRequest";
import { ExtendedTest } from "../models/test/ExtendedTest";
import { Test } from "../models/test/Test"
import API from "./repository/API"

const TestRepository = {
    getTests: async (): Promise<Test[] | undefined> => {
        try {
            const response = await API.get<Test[]>('/tests')
            return response.data
        }
        catch (e) {
            console.error(e)
        }
    },

    getTest: async (id: string): Promise<ExtendedTest | undefined> => {
        try {
            const response = await API.get<ExtendedTest>(`/tests/${id}`)
            return response.data
        }
        catch (e) {
            console.error(e)
        }
    },

    sumbitAnswers: async (request: AnswersRequest): Promise<boolean> => {
        try {
            const response = await API.post<AnswersRequest, { mark: number }>('/tests/answer', request)
            return response.success
        }
        catch (e) {
            return false
        }
    }
}

export default TestRepository;