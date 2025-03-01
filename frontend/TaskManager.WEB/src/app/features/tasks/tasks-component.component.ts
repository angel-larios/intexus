import { Component } from '@angular/core';
import { TaskListComponent } from './components/tasks-list/tasks-list.component';
import { TaskFilter } from '../../core/models/tasks-filter.model';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { CreateTaskModalComponent } from './components/create-task-modal/create-task-modal.component';
import { FormsModule } from '@angular/forms';
import { TasksService } from '../../core/services/tasks/tasks.service';

@Component({
  selector: 'app-tasks-component',
  standalone: true,
  imports: [TaskListComponent, FormsModule, MatDialogModule],
  templateUrl: './tasks-component.component.html',
  styleUrl: './tasks-component.component.scss'
})
export class TasksComponentComponent {
  filters: TaskFilter = { title: '', isCompleted: null };

  constructor(private dialog: MatDialog, private taskService: TasksService) {}

  openCreateTaskModal(): void {
    const dialogRef = this.dialog.open(CreateTaskModalComponent, {
      width: '420px', 
      disableClose: false,
      hasBackdrop: true,
      backdropClass: 'custom-backdrop',
      panelClass: 'custom-modal'
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        
      }
    });
  }
  createTask(title: string){
      this.taskService.createTask(title).subscribe(() => this.applyFilters('', null));
  }
  
  applyFilters(title: string, isCompleted: boolean | null): void {
    this.filters = { title, isCompleted };
  }

  clearFilters(): void {
    this.filters = { title: '', isCompleted: null };
  }
}
