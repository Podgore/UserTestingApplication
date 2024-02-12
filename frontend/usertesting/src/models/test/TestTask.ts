import { TaskOption } from "./TaskOption";

export interface TestTask {
    id: string;
    label: string;
    options: TaskOption[];
}