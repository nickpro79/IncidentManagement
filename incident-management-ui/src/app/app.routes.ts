import { Routes } from '@angular/router';
import { Dashboard } from './pages/dashboard/dashboard';
import { Tickets } from './pages/tickets/tickets';

export const routes: Routes = [
  { path: '', component: Dashboard },
  { path: 'tickets', component: Tickets }
];