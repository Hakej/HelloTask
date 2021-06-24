import { Component, Inject } from "@angular/core";
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData, TabComponent } from "../tab.component";

@Component({
    selector: 'tab-dialog',
    templateUrl: 'tab-dialog.component.html',
})
export class TabDialog {
    tabName = "";

    constructor(
        public dialogRef: MatDialogRef<TabComponent>,
        @Inject(MAT_DIALOG_DATA) public data: DialogData) {
        this.tabName = data.tabName;
    }

    onNoClick(): void {
        this.dialogRef.close();
    }

    onDeleteClick() {
        if (confirm(`Are you sure to delete the ${this.tabName}?`)) {
            this.data.shouldBeDeleted = true;
            this.dialogRef.close(this.data);
        }
    }
}
