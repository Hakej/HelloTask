import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Assignment } from '../shared/assignment.model';
import { TabCacheService } from '../shared/tab-cache.service';
import { TabDialog } from './tab-dialog/tab-dialog.component';

export interface DialogData {
  tabName: string
  shouldBeDeleted: boolean;
}

@Component({
  selector: 'app-tab',
  templateUrl: './tab.component.html',
  styleUrls: ['./tab.component.scss'],
  providers: [TabCacheService]
})
export class TabComponent implements OnInit {
  @Input() tabId = 0;
  isTabSelected = false;

  newAssignment: Assignment = new Assignment();

  constructor(public tabCache: TabCacheService,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.tabCache.fetchCachedTab(this.tabId);
  }

  get tab() {
    return this.tabCache.tab;
  }

  deleteTab() {
    this.tabCache.deleteTab(this.tabId);
  }

  selectTab() {
    this.isTabSelected = true;
    this.openDialog();
  }

  openDialog() {
    const dialogRef = this.dialog.open(TabDialog, {
      data: {
        tabName: this.tab.name
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.isTabSelected = false;
      if (result) {
        if (result.shouldBeDeleted) {
          this.tabCache.deleteTab(this.tabId);
        } else {
          this.tabCache.putTab(result.tabName);
        }
      }
    });
  }

  addAssignment() {
    this.tabCache.addAssignment(this.newAssignment);
    this.newAssignment = new Assignment();
  }

  resetForm(form: NgForm) {
    form.form.reset();
  }

  onAssignmentDeleted(id: number) {
    let index = this.tabCache.tab.assignments.findIndex(a => a.id === id);
    this.tabCache.tab.assignments.splice(index, 1);
  }
}
