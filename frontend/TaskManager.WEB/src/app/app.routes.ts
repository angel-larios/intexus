import { Routes } from '@angular/router';

export const appRoutes: Routes = [
  {
    path: 'tasks',
    loadComponent: () => import('./features/tasks/tasks-component.component')
      .then(m => m.TasksComponentComponent)
  },
  { path: '', redirectTo: 'tasks', pathMatch: 'full' }
];
