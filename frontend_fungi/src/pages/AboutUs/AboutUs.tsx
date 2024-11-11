import React from 'react';
import './index.css';

const AboutUs: React.FC = () => {
  return (
    <div className="about">
      <header className="header">
        <img src="/logo.png" alt="Fungi logo" className="logo" />
        <nav>
          <ul className="nav-links">
            <li>О нас</li>
            <li>Публикации</li>
            <li>Энциклопедия</li>
          </ul>
        </nav>
      </header>
      
      <section className="intro">
        <h1>Fungi - твой помощник в мире грибов.</h1>
        <p>
          Команда разработчиков случайно пришла к идее создания простого и эффективного сервиса, помогающего
          любителям собирать грибы, не напрягаясь.
        </p>
        <p>
          Из этой идеи родилось приложение Fungi – электронная энциклопедия о грибах, которая предоставляет 
          пользователям информацию о залежах грибов, их приготовлениях, интересных фактах и многом другом.
        </p>
        <p><strong>Цель проекта - облегчить жизнь любителям грибов</strong></p>
      </section>
      
      <section className="features">
        <h2>Всё о грибах в одном месте!</h2>
        <div className="feature-cards">
          <div className="card">
            <img src="/icon1.png" alt="icon1" />
            <p>Офлайн доступ к 100 видам грибов в твоём телефоне.</p>
          </div>
          <div className="card">
            <img src="/icon2.png" alt="icon2" />
            <p>С полезной информацией, чтобы точно отличить мухомор от съедобного гриба.</p>
          </div>
          <div className="card">
            <img src="/icon3.png" alt="icon3" />
            <p><strong>30+</strong> статей</p>
          </div>
        </div>
      </section>
      
      <section className="join">
        <h3>Стань частью грибного сообщества!</h3>
      </section>
    </div>
  );
};

export default AboutUs;
