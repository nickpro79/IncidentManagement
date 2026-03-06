import { Routes } from '@angular/router';
import { Dashboard} from './pages/dashboard/dashboard';
import { Tickets } from './pages/tickets/tickets';
import { Login } from './pages/login/login';
import { Register } from './pages/register/register';

export const routes: Routes = [

  { path: 'login', component: Login },
  { path: 'register', component: Register },

  { path: '', component: Dashboard },
  { path: 'tickets', component: Tickets }

];