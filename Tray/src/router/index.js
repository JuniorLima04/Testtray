import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Cadastro from '../views/Cadastro.vue'
import Compra from '../views/Compra.vue'




const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/about',
      name: 'about',
      component: () => import('../views/AboutView.vue')
    },
    {
      path: '/cad',
      name: 'cadastro',
      component: () => import('../views/Cadastro.vue')
    },
    {
      path: '/com',
      name: 'compra',
      component: () => import('../views/Compra.vue')
    },
    {
      path: '/cart/:brand',
      name: 'cart',
      component: () => import('../views/Cart.vue')
    },
    
  ]
})

export default router
