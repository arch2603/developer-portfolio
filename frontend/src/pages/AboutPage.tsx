import { useEffect, useState } from 'react';
import { getAbout } from '../api/aboutApi';
import type { About } from '../types/about';

export function AboutPage() {
    const [about, setAbout] = useState<About | null>(null);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        getAbout()
            .then(setAbout)
            .catch(() => setError('Unable to load About information.'));
    }, []);

    if (error) {
        return <p>{error}</p>;
    }

    if (!about) {
        return <p>Loading...</p>;
    }

    return (
        <article>
            <h1>{about.heading}</h1>

            <p>{about.introduction}</p>

            <p>{about.biography.split('\n\n').map((paragraph, index) => <p key={index}>{paragraph}</p>)}</p>

            <p>
                <strong>Location:</strong> {about.location}
            </p>

            <p>
                <strong>Availability:</strong> {about.availability}
            </p>

            <h2>Capabilities</h2>

            <ul>
                {about.capabilities.map((capability) => (
                    <li key={capability}>{capability}</li>
                ))}
            </ul>
        </article>
    );
}