<template>
    <header id="header" class="fixed-top d-flex align-items-center">
      <div class="container">
        <div class="header-container d-flex align-items-center justify-content-between">
          <div class="logo">
            <h1 class="logo-text">SneakerWorld</h1>
          </div>
          <nav id="navbar" class="navbar">
            <ul class="d-flex justify-content-center list-unstyled mb-0">
              <li class="mx-3">
                <a class="nav-link highlight" href="/cad">Cadastre-se</a>
              </li>
              <li class="mx-3">
                <a class="nav-link highlight" href="/com">Comprar</a>
              </li>
              <li class="mx-3">
                <a class="nav-link" href="/">Inicio</a>
              </li>
            </ul>
            <i class="bi bi-list mobile-nav-toggle" style="font-size: 1.5rem; color: #333; cursor: pointer;"></i>
          </nav>
        </div>
      </div>
    </header>
  
    <section id="hero" class="d-flex align-items-center justify-content-center position-relative" style="height: 100vh; overflow: hidden;">
      <img src="../assets/tenisnovo.jpg" alt="Imagem" class="img-fluid position-absolute w-100 h-100" style="object-fit: cover; z-index: -1;">
      <div class="overlay" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%; background-color: rgba(0, 0, 0, 0.5);"></div>
      <div class="container text-center position-relative" data-aos="fade-in" data-aos-delay="200" style="z-index: 1;">
        <h1 class="hero-title">Sua Loja de Tênis Online</h1>
        <h2 class="hero-subtitle">Experiência de compra incrível</h2>
        <a href="/com" class="btn btn-primary btn-lg hero-button">Explore os Produtos</a>
      </div>
    </section>
  
    <section id="clients" class="fixed-bottom d-flex" style="background-color: white; padding-top: 5px !important; padding-bottom: 5px !important;">
      <div class="container">
        <div class="row">
          <div class="col-lg-2 col-md-4 col-6 d-flex align-items-center" data-aos="zoom-in" data-aos-delay="100">
            <a href="/com?brand=Adidas">
              <img src="../assets/client-1.png" class="img-fluid" alt="Imagem">
            </a>
          </div>
          <div class="col-lg-2 col-md-4 col-6 d-flex align-items-center" data-aos="zoom-in" data-aos-delay="200">
            <a href="/com?brand=Nike">
              <img src="../assets/client-2.png" class="img-fluid" alt="Imagem">
            </a>
          </div>
          <div class="col-lg-2 col-md-4 col-6 d-flex align-items-center" data-aos="zoom-in" data-aos-delay="300">
            <a href="/com?brand=Lacoste">
              <img src="../assets/client-3.png" class="img-fluid" alt="Imagem">
            </a>
          </div>
          <div class="col-lg-2 col-md-4 col-6 d-flex align-items-center" data-aos="zoom-in" data-aos-delay="400">
            <a href="/com?brand=Puma">
              <img src="../assets/client-4.png" class="img-fluid" alt="Imagem">
            </a>
          </div>
          <div class="col-lg-2 col-md-4 col-6 d-flex align-items-center" data-aos="zoom-in" data-aos-delay="500">
            <a href="/com?brand=NB">
              <img src="../assets/client-5.png" class="img-fluid" alt="Imagem">
            </a>
          </div>
          <div class="col-lg-2 col-md-4 col-6 d-flex align-items-center" data-aos="zoom-in" data-aos-delay="600">
            <a href="/com?brand=Vans">
              <img src="../assets/client-6.png" class="img-fluid" alt="Imagem">
            </a>
          </div>
        </div>
      </div>
    </section>
  
    <a href="#" class="back-to-top d-flex align-items-center justify-content-center">
      <i class="bi bi-arrow-up-short"></i>
    </a>
  </template>
  
  <script>
  export default {
    methods: {
      closeWelcomeDiv() {
        document.getElementById('welcome-div').style.display = "none"
      }
    }
  }
  </script>
  
  <style>
  /* General Navbar Styles */
  #navbar {
    background-color: rgba(255, 255, 255, 0.9); /* More opaque background for better visibility */
  }
  
  .navbar ul {
    padding: 0; /* Remove default padding */
  }
  
  .navbar .nav-link {
    font-family: 'Roboto', sans-serif;
    font-size: 1.2rem;
    color: #333;
    text-transform: uppercase;
    letter-spacing: 1px;
    font-weight: 500;
    text-decoration: none; /* Remove underline */
  }
  
  .navbar .nav-link:hover {
    color: #ff6600; /* Change on hover for a visual effect */
  }
  
  .highlight {
    color: #ff6600; /* Highlight for important links */
  }
  
  /* Header Logo Styles */
  .logo-text {
    font-family: 'Roboto', sans-serif;
    font-size: 2.5rem;
    font-weight: 600;
    color: #333;
    text-transform: uppercase;
    letter-spacing: 1.5px;
    margin: 0;
  }
  
  /* Hero Section Styles */
  .hero-title {
    font-size: 3.5rem;
    font-weight: bold;
    color: white;
    text-shadow: 2px 2px 8px rgba(0, 0, 0, 0.7);
  }
  
  .hero-subtitle {
    font-size: 2rem;
    font-weight: 300;
    color: white;
    margin-bottom: 30px;
    text-shadow: 2px 2px 8px rgba(0, 0, 0, 0.7);
  }
  
  .hero-button {
    font-size: 1.5rem;
    padding: 15px 30px;
    border-radius: 50px;
    background-color: #ff4500;
    border: none;
  }
  
  /* Client Section Styles */
  #clients {
    background-color: white;
    padding: 5px 0; /* Uniform padding */
  }
  
  /* Back to Top Button */
  .back-to-top {
    position: fixed;
    bottom: 20px;
    right: 20px;
    background-color: rgba(255, 255, 255, 0.8);
    border-radius: 50%;
    padding: 10px;
    display: none; /* Hidden by default */
  }
  
  .back-to-top.show {
    display: flex; /* Show when scrolled down */
  }
  
  /* Responsive Adjustments */
  @media (max-width: 768px) {
    .mobile-nav-toggle {
      display: block; /* Show toggle for mobile */
    }
    .navbar ul {
      flex-direction: column; /* Stack items vertically on mobile */
      display: none; /* Hide initially */
    }
    .navbar.active ul {
      display: flex; /* Show when active */
    }
  }
  </style>
  