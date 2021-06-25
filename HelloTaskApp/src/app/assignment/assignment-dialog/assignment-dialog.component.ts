import { Component, Inject } from "@angular/core";
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Assignment } from "src/app/shared/assignment.model";
import { AssignmentComponent } from "../assignment.component";

export interface AssignmentData {
  assignment: Assignment,
  shouldBeDeleted: boolean;
}

@Component({
  selector: 'assignment-dialog',
  templateUrl: 'assignment-dialog.component.html',
})
export class AssignmentDialogComponent {
  assignmentName = "";

  constructor(
    public dialogRef: MatDialogRef<AssignmentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AssignmentData) {
    this.assignmentName = data.assignment.name;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onDeleteClick() {
    if (confirm(`Are you sure to delete the ${this.assignmentName}?`)) {
      this.data.shouldBeDeleted = true;
      this.dialogRef.close(this.data);
    }
  }
}
