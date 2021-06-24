import { EventEmitter, Input, Output } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Assignment } from '../shared/assignment.model';
import { AssignmentService } from '../shared/assignment.service';
import { AssignmentDialogComponent } from './assignment-dialog/assignment-dialog.component';

@Component({
  selector: 'app-assignment',
  templateUrl: './assignment.component.html',
  styleUrls: ['./assignment.component.scss']
})
export class AssignmentComponent implements OnInit {
  @Input()
  assignment: Assignment;
  isSelected = false;

  @Output()
  assignmentDelete = new EventEmitter<number>();

  constructor(public assignmentService: AssignmentService,
    private toastr: ToastrService,
    public dialog: MatDialog) {
  }

  ngOnInit(): void {
  }

  onDelete(id: number) {
    this.assignmentService.deleteAssignment(id)
      .subscribe(
        res => {
          this.assignmentDelete.emit(id);
          this.toastr.info("Assignment deleted successfully", "Assignment deletion");
        }, err => { console.log(err) }
      )
  }

  onPut() {
    this.assignmentService.putAssignment();
  }

  selectAssignment() {
    this.isSelected = true;
    this.openDialog();
  }

  openDialog() {
    const dialogRef = this.dialog.open(AssignmentDialogComponent, {
      data: {
        assignmentName: this.assignment.name
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.isSelected = false;
      console.log(result);
      if (result) {
        if (result.shouldBeDeleted) {
          this.onDelete(this.assignment.id)
        } else {

          this.onPut();
        }
      }
    });
  }
}
