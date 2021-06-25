import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Assignment } from './assignment.model';
import { Tab } from './tab.model';
import { TabService } from './tab.service';

@Injectable({
  providedIn: 'root'
})
export class TabCacheService {
  tab!: Tab;

  constructor(private tabService: TabService,
    private toastr: ToastrService) { }

  fetchCachedTab(id: number) {
    if (!this.tab) {
      this.tabService.getTab(id)
        .toPromise()
        .then(response => this.tab = response as Tab);
    }

    return this.tab;
  }

  deleteTab(id: number) {
    this.tabService.deleteTab(id)
      .subscribe(
        res => {
          this.toastr.info("Tab deleted successfully", "Tab deletion");
          this.tabService.getTabs();
        },
        err => { console.log(err) }
      )
  }

  renameTab(newTabName: string) {
    this.tabService.putTab(this.tab).toPromise()
      .then(res => {
        this.tab.name = newTabName;
        this.toastr.info("Tab updated successfully.", "Tab update");
      }, err => { console.log(err) });
  }

  addAssignment(newAssignment: Assignment) {
    this.tabService.postAssignment(this.tab.id, newAssignment)
      .subscribe(
        res => {
          this.tab.assignments.push(res as Assignment);
        },
        err => { console.log(err) }
      )
  }
}
