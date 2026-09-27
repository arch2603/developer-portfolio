import type { ContactRequest, ProjectDetail, ProjectSummary } from '../types/project'

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || ''

async function request<T>(url:string, options?:RequestInit):Promise<T> {
  console.log('API_BASE_URL =', API_BASE_URL)
  const response = await fetch(`${API_BASE_URL}${url}`, { ...options, headers:{ 'Content-Type':'application/json', ...options?.headers } })
  if (!response.ok) throw new Error(`Request failed: ${response.status}`)
  
    return response.json() as Promise<T>
}

export const api = {
  getProjects: () => request<ProjectSummary[]>(`/api/projects`),
  getProject: (slug:string) => request<ProjectDetail>(`/api/projects/${encodeURIComponent(slug)}`),
  sendContact: (body:ContactRequest) => request<{message:string}>(`/api/contact`, { method:'POST', body:JSON.stringify(body) }),
}