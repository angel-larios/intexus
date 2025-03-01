import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-alert-modal',
  templateUrl: './alert-modal.component.html',
  standalone: true,
  imports: [CommonModule, MatIconModule],
  styleUrls: ['./alert-modal.component.scss']
})
export class AlertModalComponent {
  constructor(
    public dialogRef: MatDialogRef<AlertModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { message: string, type: 'success' | 'error' }
  ) {}

  close(): void {
    this.dialogRef.close();
  }
}
