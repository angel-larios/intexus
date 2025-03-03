import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { TasksService } from '../../../../core/services/tasks/tasks.service';
import { AlertModalComponent } from '../../../../shared/components/alert-modal/alert-modal.component';
import { LoaderComponent } from '../../../../shared/components/loader/loader.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-create-task-modal',
  standalone: true,
  imports: [ReactiveFormsModule, LoaderComponent, CommonModule],
  templateUrl: './create-task-modal.component.html',
  styleUrl: './create-task-modal.component.scss'
})
export class CreateTaskModalComponent {
  taskForm: FormGroup;
  loading = false;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<CreateTaskModalComponent>,
    private dialog: MatDialog,
    public taskService: TasksService
  ) {
    this.taskForm = this.fb.group({
      title: ['', Validators.required]
    });
  }
  createTask(title: any): void {
    this.taskService.createTask(title).subscribe({
      next: () => {
        this.loading = false;
        this.openAlertModal('Tarea creada exitosamente', 'success');
        this.dialogRef.close(true); 
      },
      error: () => {
        this.loading = false;
        this.openAlertModal('Error al crear la tarea', 'error');
      }
    });
  }

  openAlertModal(message: string, type: 'success' | 'error'): void {
    this.dialog.open(AlertModalComponent, {
      width: '350px',
      data: { message, type }
    });
  }
  save(): void {
    this.loading = true;
    var data = {
      title: this.taskForm.get('title')?.value
    }
    if (this.taskForm.valid) {
      this.createTask(data)
    }
  }
}
