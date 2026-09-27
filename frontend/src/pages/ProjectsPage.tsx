import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import { api } from '../api/client'
import type { ProjectSummary } from '../types/project'

export function ProjectsPage() {
  console.log('Projects page loaded');
  const [items,setItems]=useState<ProjectSummary[]>([]), [loading,setLoading]=useState(true), [error,setError]=useState('')
  
  useEffect(()=>{ api.getProjects().then(setItems).catch(()=>setError('Projects could not be loaded.')).finally(()=>setLoading(false)) },[])
  
  if (loading) return <p>Loading projects…</p>

  if (error) return <p role="alert">{error}</p>
  
  return (
    <section><h1>Projects</h1><div className="project-grid">{items.map(p=><article className="card" key={p.slug}>
      <h2><Link to={`/projects/${p.slug}`}>{p.title}</Link></h2><p>{p.summary}</p>
      <ul className="tags">{p.technologies.map(t=><li key={t}>{t}</li>)}</ul>
    </article>)}</div></section>
  )
}