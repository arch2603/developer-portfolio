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
    const biographyParagraphs = about.biography.split(/\r?\n\r?\n/);
    return (
        <article>
            <section className="about-hero">
                <p className="about-eyebrow">About me</p>
                <h1>{about.heading}</h1>
                <p>{about.introduction}</p>
                <div className="about-meta">
                    <span>Location: {about.location}</span>
                    <span className="about-availability">Availability: {about.availability}</span>
                </div>
            </section>

            <section className="about-section about-story">
                <div className="about-section-heading">
                    <p className="about-eyebrow">Background</p>
                    <h2>My Professional Journey</h2>
                </div>

                <div className="about-biography">
                    {biographyParagraphs.map((paragraph, index) => (
                        <p key={index}>{paragraph}</p>
                    ))}
                </div>
            </section>

            <section className="about-section">
                <div className="about-section-heading">
                    <p className="about-eyebrow">Technology</p>
                    <h2>Technical capabilities</h2>
                </div>

                <div className="capability-grid">
                    {about.capabilities.map((capability) => (
                        <span className="capability-badge" key={capability}>
                            {capability}
                        </span>
                    ))}
                </div>
            </section>

            <section className="about-section">
                <div className="about-section-heading">
                    <p className="about-eyebrow">Experience</p>
                    <h2>What I bring</h2>
                </div>

                <div className="about-strengths">
                    <div className="about-strength-card">
                        <h3>Full-stack development</h3>
                        <p>
                            Building frontend experiences, backend services,
                            REST APIs and relational database solutions.
                        </p>
                    </div>

                    <div className="about-strength-card">
                        <h3>Cloud & deployment</h3>
                        <p>
                            Deploying and supporting applications using AWS,
                            Linux, Nginx, Docker and CI/CD practices.
                        </p>
                    </div>

                    <div className="about-strength-card">
                        <h3>Systems experience</h3>
                        <p>
                            Combining software development with systems
                            analysis, troubleshooting, databases and
                            production support.
                        </p>
                    </div>
                </div>
            </section>
        </article>
    );
}