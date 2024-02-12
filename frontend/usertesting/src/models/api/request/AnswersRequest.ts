import { TaskAnswer } from "./TaskAnswer";

export interface AnswersRequest {
    testId: string;
    taskAnswers: TaskAnswer[];
};
