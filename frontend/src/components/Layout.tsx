import { NavLink, Outlet } from 'react-router-dom'
export function Layout() {
  return <>
    <header className="site-header"><nav className="container" aria-label="Main navigation">
      <NavLink className="brand" to="/">Archie Su'a</NavLink>
      <div className="nav-links">
        <NavLink to="/projects">Projects</NavLink>
        <NavLink to="/experience">Experience</NavLink>
        <NavLink to="/about">About</NavLink>
        <NavLink to="/contact">Contact</NavLink></div>
    </nav></header>
    <main className="container"><Outlet /></main>
    <footer className="container">© {new Date().getFullYear()} Archie Su'a</footer>
  </>
}