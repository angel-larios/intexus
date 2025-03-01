import { environment } from "../../../environments/environment";

export const API_ENDPOINTS = {
  TASKS: `${environment.apiUrl}/api/tasks`,
};


export const ApiServicesUrls = {
  tasks: {
    getAll: API_ENDPOINTS.TASKS,
    getTaskById: `${API_ENDPOINTS.TASKS}/userById/`,
    createTask: `${environment.apiUrl}/api/tasks`,
    updateTask: `${environment.apiUrl}/api/tasks/`,
    deleteTask: `${environment.apiUrl}/api/tasks/`
  },
}