import React, {Component} from "react";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import "./index.css";
import {MainPage} from "./pages/MainPage.tsx";
import "./components/Header/header.tsx";
import {Header} from "./components/Header/header.tsx";
import { Footer } from "./components/Footer/footer.tsx";
import AboutUs from "./pages/AboutUs/AboutUs.tsx";
//import {Footer} from "./components/Footer/footer.tsx";

export function App() {

  return (
    <div className='wrapper'>
      <BrowserRouter>
      <Header />
        <Routes>
          <Route path="/about" element={
            <AboutUs/>
          }/>
          <Route path="/mainpage" element={
            <MainPage />
          } />
          <Route path="*" element={<Navigate to="/mainpage"/>}/>
        </Routes>
        <Footer />
      </BrowserRouter>
    </div>
  )
}

export default App
