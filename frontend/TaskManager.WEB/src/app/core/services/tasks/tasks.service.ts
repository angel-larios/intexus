import { Injectable } from '@angular/core';
import { BaseApiService } from '../base-api.service';
import { ApiServicesUrls } from '../const/const';
import { Observable } from 'rxjs';
import { Task } from 'zone.js/lib/zone-impl';
import { TaskFilter } from '../../models/tasks-filter.model';

@Injectable({
  providedIn: 'root',
})
export class TasksService {
  constructor(private apiService: BaseApiService) {}

  getAllTasks(filters?: TaskFilter): Observable<any> {
    let url = ApiServicesUrls.tasks.getAll;
    if (filters) {
      
      const queryParams = new URLSearchParams();
      
      if (filters.title) queryParams.append('title', filters.title);
      if (filters.isCompleted != null) queryParams.append('isCompleted', filters.isCompleted.toString());

      if (queryParams.toString()) {
        url = `${url}?${queryParams.toString()}`;
      }
      
    }

    return this.apiService.get<any>(url);
  }

  getTaskById(taskId: string): Observable<Task> {
    return this.apiService.get<Task>(`${ApiServicesUrls.tasks.getTaskById}${taskId}`);
  }

  deleteTask(taskId: string): Observable<any> {
    return this.apiService.delete<any>(`${ApiServicesUrls.tasks.deleteTask}${taskId}`);
  }
  updateTask(taskId: string, body: any): Observable<any> {
    return this.apiService.patch<any>(`${ApiServicesUrls.tasks.updateTask}${taskId}`, body);
  }
  createTask(task: any): Observable<any> {
    return this.apiService.post<any>(ApiServicesUrls.tasks.createTask, task);
  }

}
