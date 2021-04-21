export interface Student {
    id: number;
    name: string;
    projectId: number;
}

export interface Project {
    id: number;
    name: string;
    description: string;
    students: Student[];
}
