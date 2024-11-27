import './assets/style.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import PessoaDataService from "./services/PessoaService";

const app = createApp(App)

// Teste para chamar o back
PessoaDataService.getAll();

app.use(router)

app.mount('#app')
