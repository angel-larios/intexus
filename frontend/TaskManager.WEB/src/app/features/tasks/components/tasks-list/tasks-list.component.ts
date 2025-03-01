import { Component, Input, OnChanges, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

import { TasksService } from '../../../../core/services/tasks/tasks.service';
import { Task } from '../../../../core/models/task.model';
import { TaskFilter } from '../../../../core/models/tasks-filter.model';
import { LoaderComponent } from '../../../../shared/components/loader/loader.component';
import { Observable } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatCheckboxModule,
    MatIconModule,
    MatButtonModule,
    MatPaginatorModule, 
    LoaderComponent
  ],
  templateUrl: './tasks-list.component.html',
  styleUrls: ['./tasks-list.component.scss']
})
export class TaskListComponent implements OnChanges {
  @Input() filters!: TaskFilter;
  tasks$!: Observable<Task[]>;
  dataSource = new MatTableDataSource<Task>();

  loading = false;
  displayedColumns: string[] = ['title', 'completed', 'actions'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private taskService: TasksService) {}

  ngOnChanges(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.loading = true;
    this.tasks$ = this.taskService.getAllTasks(this.filters);
    this.tasks$.subscribe(tasks => {
      this.dataSource.data = tasks || []; 
      this.dataSource.paginator = this.paginator; 
      this.loading = false;
    });
  }

  deleteTask(id: string): void {
    this.loading = true;
    this.taskService.deleteTask(id).subscribe(() => this.loadTasks());
  }

  toggleComplete(task: Task): void {
    this.loading = true;
    this.taskService.updateTask(task.id, { isCompleted: !task.isCompleted }).subscribe(() => this.loadTasks());
  }
}
