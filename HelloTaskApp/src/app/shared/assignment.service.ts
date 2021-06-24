import { Injectable } from '@angular/core';
import { Assignment } from './assignment.model';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class AssignmentService {

  constructor(private http: HttpClient) { }

  assignmentData: Assignment = new Assignment();
  readonly baseURL = "https://localhost:5001/api/Assignments"

  postAssignment(id: number) {
    return this.http.post(`${this.baseURL}/AddAssignment/${id}`, this.assignmentData)
  }

  putAssignment() {
    return this.http.put(`${this.baseURL}/${this.assignmentData.id}`, this.assignmentData)
  }

  deleteAssignment(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`)
  }
}
