import { TestTask } from "./TestTask";

export interface ExtendedTest {
    id: string;
    lable: string;
    maxMark: number;
    tasks: TestTask[];
}