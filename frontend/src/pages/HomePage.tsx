import { Link } from 'react-router-dom'
export function HomePage() {
  return <section className="hero"><p className="eyebrow">Full-stack developer</p>
    <h1>I build practical web applications from database to deployment.</h1>
    <p>React, TypeScript, C#, ASP.NET Core, PostgreSQL, Linux, Nginx, Cloudflare, and AWS.</p>
    <div className="actions"><Link className="button" to="/projects">View projects</Link><Link className="button secondary" to="/contact">Contact me</Link></div>
  </section>
}