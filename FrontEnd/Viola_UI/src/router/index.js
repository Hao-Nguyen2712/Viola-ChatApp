import { createRouter, createWebHistory } from 'vue-router'

import home from '@/pages/home.vue'
import login from '@/pages/login.vue'
import signup from '@/pages/signup.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: home,
  },
  {
    path: '/login',
    name: 'Login',
    component: login,
  },
  {
    path: '/signup',
    name: 'Signup',
    component: signup,
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router
