import { Routes } from '@angular/router';

import { Login } from './pages/login/login';
import { Register } from './pages/register/register';

import { Dashboard } from './pages/dashboard/dashboard';
import { Tickets } from './pages/tickets/tickets';

import { AppLayout } from './layout/app-layout/app-layout';

export const routes: Routes = [

  // AUTH PAGES
  { path: 'login', component: Login },
  { path: 'register', component: Register },

  // MAIN APPLICATION
  {
    path: '',
    component: AppLayout,
    children: [
      { path: '', component: Dashboard },
      { path: 'tickets', component: Tickets }
    ]
  }

];