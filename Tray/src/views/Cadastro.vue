<template>
  <div class="container">
    <header id="header" class="fixed-top d-flex align-items-center" style="background-color: #1e2a47; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2); padding: 10px 0;">
  <div class="container">
    <div class="header-container d-flex align-items-center justify-content-between">
      
      <!-- Logo Section -->
      <div class="logo me-auto">
        <h1 class="logo-text text-white mb-0" style="font-family: 'Poppins', sans-serif; font-weight: 600; font-size: 1.5rem;">
          SneakerWorld
        </h1>
      </div>

      <!-- Navigation Section -->
      <nav id="navbar" class="navbar navbar-expand-lg navbar-dark">
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav ms-auto">
            <li class="nav-item">
              <a class="nav-link text-white" href="/" style="font-size: 1.1rem; padding: 8px 20px; transition: 0.3s ease;">
                Início
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link text-white highlight" href="/cad" style="font-size: 1.1rem; padding: 8px 20px; background: linear-gradient(90deg, #f39c12 0%, #f39c12 100%); border-radius: 5px; color: white; transition: 0.3s ease;">
                Cadastre-se
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link text-white highlight" href="/com" style="font-size: 1.1rem; padding: 8px 20px; background: linear-gradient(90deg, #f39c12 0%, #f39c12 100%); border-radius: 5px; color: white; transition: 0.3s ease;">
                Comprar
              </a>
            </li>
          </ul>
        </div>
      </nav>
    </div>
  </div>
</header>


    <!-- Conteúdo -->
    <div class="registration-container">
      <h2>Cadastro</h2>
      <form @submit.prevent="submitForm" class="registration-form">
        <div class="form-group">
          <label for="nome">Nome:</label>
          <input type="text" id="nome" v-model="formData.nome" class="form-control" required>
        </div>
        <div class="form-group">
          <label for="email">Email:</label>
          <input type="email" id="email" v-model="formData.email" class="form-control" required>
        </div>
        <div class="form-group">
          <label for="senha">Senha:</label>
          <input type="password" id="senha" v-model="formData.senha" class="form-control" required>
        </div>
        <button type="submit" class="btn-submit">Cadastrar</button>
        <p v-if="successMessage" class="alert alert-success">{{ successMessage }}</p>
        <p v-if="errorMessage" class="alert alert-danger">{{ errorMessage }}</p>
      </form>
    </div>
  </div>
</template>

<script>
import PessoaService from '@/services/PessoaService';

export default {
  name: "CadastroPessoa",
  data() {
    return {
      formData: {
        nome: '',
        email: '',
        senha: ''
      },
      successMessage: '',
      errorMessage: ''
    };
  },
  methods: {
    submitForm() {
      PessoaService.create(this.formData)
        .then(response => {
          this.successMessage = 'Cadastro realizado com sucesso!';
          this.errorMessage = '';
          this.resetForm();
        })
        .catch(error => {
          if (error.response && error.response.status === 500) {
            this.errorMessage = 'Erro no servidor ao realizar o cadastro.';
          } else if (error.response && error.response.status === 400) {
            this.errorMessage = 'Erro ao realizar o cadastro. Verifique seus dados.';
          } else {
            this.errorMessage = 'Erro ao realizar o cadastro. Tente novamente mais tarde.';
          }
          this.successMessage = '';
        });
    },
    resetForm() {
      this.formData.nome = '';
      this.formData.email = '';
      this.formData.senha = '';
    }
  }
  
};
</script>

<style scoped>
/* Formulário de Registro */
.registration-container {
  background-color: #fff;
  width: 80%; /* Aumentado para ocupar mais largura */
  height: 90vh; /* Quase a altura total da tela */
  display: flex;
  flex-direction: column; /* Mantém alinhado o conteúdo */
  justify-content: center;
  align-items: center;
  padding: 20px;
  margin: auto;
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
}

.registration-container h2 {
  text-align: center;
  margin-bottom: 20px;
  color: #333;
  font-size: 2rem; /* Título maior */
  font-weight: bold;
}

.registration-form {
  width: 100%; /* Ocupa toda a largura do contêiner */
  max-width: 600px; /* Máximo para não ultrapassar o limite */
}

.form-group {
  margin-bottom: 20px;
}

label {
  display: block;
  margin-bottom: 8px;
  font-weight: 600;
  color: #555;
}

.form-control {
  width: 100%;
  padding: 15px; /* Mais espaçamento interno */
  border: 1px solid #ddd;
  border-radius: 8px;
  font-size: 1.2rem;
  transition: box-shadow 0.2s;
}

.form-control:focus {
  border-color: #ff6b00;
  box-shadow: 0 0 10px rgba(255, 107, 0, 0.3);
  outline: none;
}

.btn-submit {
  width: 100%;
  padding: 15px;
  background-color: #ff6b00;
  border: none;
  color: white;
  border-radius: 8px;
  font-size: 1.2rem;
  font-weight: bold;
  cursor: pointer;
  transition: background-color 0.3s;
}

.btn-submit:hover {
  background-color: #e65c00;
}

.alert {
  padding: 10px;
  border-radius: 5px;
  font-size: 1rem;
  margin-top: 15px;
  text-align: center;
}

.alert-success {
  background-color: #d4edda;
  color: #155724;
}

.alert-danger {
  background-color: #f8d7da;
  color: #721c24;
}
</style>


