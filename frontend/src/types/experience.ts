export interface Experience {
    id: string;
    company: string;
    role: string;
    location: string;
    startDate: string;
    endDate: string | null;
    isCurrent: boolean;
    summary: string;
    highlights: string[];
    technologies: string[];
}