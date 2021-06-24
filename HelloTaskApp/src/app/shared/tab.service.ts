import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Tab } from './tab.model';
import { Assignment } from './assignment.model';

@Injectable({
  providedIn: 'root'
})
export class TabService {

  constructor(private http: HttpClient) { }

  newTab: Tab = new Tab();
  tabs: Tab[];
  readonly baseURL = "https://localhost:5001/api/Tabs";

  getTabs() {
    this.http.get(this.baseURL)
      .toPromise()
      .then(response => this.tabs = response as Tab[]);
  }

  getTab(id: number) {
    return this.http.get(`${this.baseURL}/${id}`);
  }

  getCachedTab(id: number) {
    return this.tabs.find(tab => tab.id === id);
  }

  postTab() {
    return this.http.post(this.baseURL, this.newTab)
  }

  changeTabName(tab: Tab) {
    return this.http.put(`${this.baseURL}/ChangeTabName/${tab.id}`, tab)
  }

  deleteTab(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`)
  }

  deleteTask(taskId: number) {
    return this.http.delete(`${this.baseURL}/${taskId}`)
  }

  addAssignment(tabId: number, newAssignment: Assignment) {
    return this.http.post(`https://localhost:5001/api/Assignments/AddAssignment/${tabId}`, newAssignment)
  }
}
