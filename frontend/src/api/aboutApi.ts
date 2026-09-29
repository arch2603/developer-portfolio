import type { About } from '../types/about';

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

export async function getAbout(): Promise<About> {
    const response = await fetch(`${API_BASE_URL}/api/about`);

    if (!response.ok) {
        throw new Error(`Failed to load About information: ${response.status}`);
    }

    return response.json() as Promise<About>;
}