import { useEffect, useState } from 'react';
import { getExperiences } from '../api/experienceApi';
import type { Experience } from '../types/experience';

function formatDate(date: string | null, isCurrent = false) {
    if (isCurrent) {
        return 'Present';
    }

    if (!date) {
        return '';
    }

    const [year, month] = date.split('-');

    return new Intl.DateTimeFormat('en-AU', {
        month: 'short',
        year: 'numeric',
    }).format(new Date(Number(year), Number(month) - 1, 1));
}

export function ExperiencePage() {
    const [experiences, setExperiences] = useState<Experience[]>([]);
    const [error, setError] = useState<string | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getExperiences()
            .then(setExperiences)
            .catch(() => setError('Unable to load professional experience.'))
            .finally(() => setLoading(false));
    }, []);

    if (loading) {
        return <p>Loading...</p>;
    }

    if (error) {
        return <p>{error}</p>;
    }

    return (
        <article className="experience-page">
            <section className="experience-hero">
                <p className="experience-eyebrow">Career</p>

                <h1>Professional Experience</h1>

                <p className="experience-introduction">
                    My professional background spans software development,
                    systems analysis, IT operations, technical support and
                    technology leadership.
                </p>
            </section>

            <section className="experience-list">
                {experiences.map((experience) => (
                    <article
                        className="experience-card"
                        key={experience.id}
                    >
                        <div className="experience-card-header">
                            <div>
                                <h2>{experience.role}</h2>

                                <p className="experience-company">
                                    {experience.company}
                                </p>

                                <p className="experience-location">
                                    {experience.location}
                                </p>
                            </div>

                            <p className="experience-date">
                                {formatDate(experience.startDate)}
                                {' – '}
                                {formatDate(
                                    experience.endDate,
                                    experience.isCurrent
                                )}
                            </p>
                        </div>

                        <p className="experience-summary">
                            {experience.summary}
                        </p>

                        {experience.highlights.length > 0 && (
                            <ul className="experience-highlights">
                                {experience.highlights.map(
                                    (highlight, index) => (
                                        <li key={index}>{highlight}</li>
                                    )
                                )}
                            </ul>
                        )}

                        {experience.technologies.length > 0 && (
                            <div className="experience-technologies">
                                {experience.technologies.map(
                                    (technology) => (
                                        <span
                                            className="experience-technology"
                                            key={technology}
                                        >
                                            {technology}
                                        </span>
                                    )
                                )}
                            </div>
                        )}
                    </article>
                ))}
            </section>
        </article>
    );
}