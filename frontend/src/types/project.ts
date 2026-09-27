export interface ProjectSummary { slug:string; title:string; summary:string; isFeatured:boolean; technologies:string[] }
export interface ProjectDetail extends ProjectSummary { description:string; repositoryUrl:string|null; liveUrl:string|null }
export interface ContactRequest { name:string; email:string; subject:string; message:string; website:string }
