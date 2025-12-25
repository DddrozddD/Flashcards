import React from 'react';
import '../styles/pages/HomePage.css';

const HomePage = () => {
  return (
    <div className="container">
      
      <header className="hero">
        <h1 className="hero-title">Learn Anything.<br />Simple and Fast.</h1>
        <p className="hero-text">
          Create flashcards, train your memory, and achieve results 
          without unnecessary noise or distractions.
        </p>
        <a href="/themes" className="btn btn-primary">Start Learning</a>
      </header>

      <section className="features">
        <div className="feature-card">
          <h3 className="feature-title">Focus</h3>
          <p className="feature-desc">An interface that helps you focus solely on the material.</p>
        </div>
        
        <div className="feature-card">
          <h3 className="feature-title">Algorithm</h3>
          <p className="feature-desc">Smart repetition exactly when you start to forget.</p>
        </div>
        
        <div className="feature-card">
          <h3 className="feature-title">Freedom</h3>
          <p className="feature-desc">Create any topics: from foreign languages to coding.</p>
        </div>
      </section>

      <footer className="footer">
        <p>© 2024 FlashCards Project</p>
      </footer>

    </div>
  );
};

export default HomePage;