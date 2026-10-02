import type { Experience } from '../types/experience';

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL ?? '';

export async function getExperiences(): Promise<Experience[]> {
    const response = await fetch(`${API_BASE_URL}/api/experience`);

    if (!response.ok) {
        throw new Error(
            `Failed to load Experience information: ${response.status}`
        );
    }

    return response.json() as Promise<Experience[]>;
}