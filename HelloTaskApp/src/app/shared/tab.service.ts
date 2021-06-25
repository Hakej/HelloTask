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
  readonly reqUrl = "Tabs";

  getTabs() {
    this.http.get(this.reqUrl)
      .toPromise()
      .then(response => this.tabs = response as Tab[]);
  }

  getTab(id: number) {
    return this.http.get(`${this.reqUrl}/${id}`);
  }

  postTab() {
    return this.http.post(this.reqUrl, this.newTab)
  }

  putTab(tab: Tab) {
    return this.http.put(`${this.reqUrl}/${tab.id}`, tab)
  }

  deleteTab(id: number) {
    return this.http.delete(`${this.reqUrl}/${id}`)
  }

  deleteAssignment(assignmentId: number) {
    return this.http.delete(`${this.reqUrl}/${assignmentId}`)
  }

  postAssignment(tabId: number, newAssignment: Assignment) {
    return this.http.post(`Assignments/${tabId}`, newAssignment)
  }
}
