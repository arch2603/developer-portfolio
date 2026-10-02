import { Route, Routes } from 'react-router-dom'
import { Layout } from './components/Layout'
import { AboutPage } from './pages/AboutPage'; import { ContactPage } from './pages/ContactPage'
import { HomePage } from './pages/HomePage'; import { NotFoundPage } from './pages/NotFoundPage'
import { ProjectDetailsPage } from './pages/ProjectDetailsPage'; import { ProjectsPage } from './pages/ProjectsPage'
import { ExperiencePage } from './pages/ExperiencePage';

export default function App()
{
  return (
  <Routes>
    <Route element={<Layout/>}>
      <Route index element={<HomePage/>}/>
      <Route path="about" element={<AboutPage/>}/>
      <Route path="experience" element={<ExperiencePage/>}/>
      <Route path="projects" element={<ProjectsPage/>}/>
      <Route path="projects/:slug" element={<ProjectDetailsPage/>}/>
      <Route path="contact" element={<ContactPage/>}/>
      <Route path="*" element={<NotFoundPage/>}/>
      </Route>
  </Routes>
  );
}