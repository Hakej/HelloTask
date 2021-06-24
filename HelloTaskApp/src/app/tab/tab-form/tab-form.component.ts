import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Tab } from 'src/app/shared/tab.model';
import { TabService } from 'src/app/shared/tab.service';

@Component({
  selector: 'app-tab-form',
  templateUrl: './tab-form.component.html',
  styleUrls: ['./tab-form.component.scss']
})
export class TabFormComponent implements OnInit {
  constructor(public service: TabService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    this.insertRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postTab().subscribe(
      res => {
        this.resetForm(form);
        this.service.getTabs();
        this.toastr.success("Tab submitted successfully.", "Tab submit");
      },
      err => {
        console.log(err);
      }
    )
  }
  /*
   updateRecord(form: NgForm) {
   this.service.changeTabName().subscribe(
     res => {
       this.resetForm(form);
       this.service.getTabs();
       this.toastr.info("Tab updated successfully.", "Tab update");
     },
     err => {
       console.log(err);
     }
   )
 }
 */
  resetForm(form: NgForm) {
    form.form.reset();
    this.service.newTab = new Tab();
  }
}
