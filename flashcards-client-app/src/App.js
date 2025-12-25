import React, { useEffect, useMemo, useState } from "react"
import axios from "axios"
import "./styles/App.css"
import Themes from "./pages/Themes";
import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import HomePage from "./pages/HomePage";
import ThemeDetail from "./pages/ThemeDetail";
function App() {
  return (
    <div className="App">
      <BrowserRouter>
      <nav className="navbar">
        <Link to="/" className="logo">FlashCards.</Link>
        <div className="nav-links">
          <Link to="/themes">Themes</Link>
        </div>
        <div className="nav-links">
          <Link to="/login">Login</Link>
          <Link to="/register">Registration</Link>
        </div>
      </nav>
        <Routes>
          <Route path="/" element={<HomePage/>}/>
          <Route exact path="/themes" element={<Themes/>}/>
          <Route exact path="/themes/:id" element={<ThemeDetail/>}/>
          <Route path="*" element={<HomePage/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
