import { Injectable } from '@angular/core';
import { Assignment } from './assignment.model';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class AssignmentService {

  constructor(private http: HttpClient) { }

  assignmentData: Assignment = new Assignment();
  readonly reqUrl = "Assignments"

  postAssignment(id: number) {
    return this.http.post(`${this.reqUrl}/${id}`, this.assignmentData)
  }

  putAssignment() {
    return this.http.put(`${this.reqUrl}/${this.assignmentData.id}`, this.assignmentData)
  }

  deleteAssignment(id: number) {
    return this.http.delete(`${this.reqUrl}/${id}`)
  }
}
