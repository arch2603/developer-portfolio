import { useState } from 'react'
import type { FormEvent } from 'react'
import { api } from '../api/client'
import type { ContactRequest } from '../types/project'
const empty:ContactRequest={name:'',email:'',subject:'',message:'',website:''}
export function ContactPage(){
  const [form,setForm]=useState(empty),[status,setStatus]=useState(''),[sending,setSending]=useState(false)
  async function submit(e:FormEvent<HTMLFormElement>){ e.preventDefault(); setSending(true); setStatus('')
    try{const r=await api.sendContact(form);setStatus(r.message);setForm(empty)}catch{setStatus('Message could not be sent.')}finally{setSending(false)} }
  return <section><h1>Contact</h1><form onSubmit={submit}>
    <label>Name<input required minLength={2} maxLength={120} value={form.name} onChange={e=>setForm({...form,name:e.target.value})}/></label>
    <label>Email<input required type="email" maxLength={254} value={form.email} onChange={e=>setForm({...form,email:e.target.value})}/></label>
    <label>Subject<input required minLength={3} maxLength={200} value={form.subject} onChange={e=>setForm({...form,subject:e.target.value})}/></label>
    <label>Message<textarea required minLength={10} maxLength={4000} rows={8} value={form.message} onChange={e=>setForm({...form,message:e.target.value})}/></label>
    <label className="honeypot" aria-hidden="true">Website<input tabIndex={-1} autoComplete="off" value={form.website} onChange={e=>setForm({...form,website:e.target.value})}/></label>
    <button disabled={sending}>{sending?'Sending…':'Send message'}</button>
  </form><p role="status" aria-live="polite">{status}</p></section>
}