import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Tab } from '../shared/tab.model';
import { TabService } from '../shared/tab.service';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styles: [
  ]
})
export class BoardComponent implements OnInit {

  constructor(public service: TabService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.getTabs();
  }

  onDelete(id: number) {
    if (confirm("Are you sure to delete this tab?")) {
      this.service.deleteTab(id)
        .subscribe(
          res => {
            this.service.getTabs();
            this.toastr.success("Tab deleted successfully", "Tab deletion");
          }, err => { console.log(err) }
        )
    }
  }
}
