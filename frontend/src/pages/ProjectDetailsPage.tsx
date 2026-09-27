import { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import { api } from '../api/client'
import type { ProjectDetail } from '../types/project'

export function ProjectDetailsPage() {
  
  const {slug=''}=useParams(), [item,setItem]=useState<ProjectDetail|null>(null), [error,setError]=useState('')
  
  useEffect(()=>{ api.getProject(slug).then(setItem).catch(()=>setError('Project not found.')) },[slug])
  
  if(error) return (<p role="alert">{error}</p>); 
  if(!item) return (<p>Loading…</p>);
  
  return (
    <article>
      <h1>{item.title}</h1>
      <p className="lead">{item.summary}</p>
      <p>{item.description}</p>
      <ul className="tags">{item.technologies.map(t=><li key={t}>{t}</li>)}</ul>
      <div className="actions">
        {item.repositoryUrl&&<a href={item.repositoryUrl}>Source code</a>}
        {item.liveUrl&&<a href={item.liveUrl}>Live application</a>}
      </div>
    </article>
  )
}