import { Table } from "./internal.js";
export class tableView extends Table {
    constructor(tableInfo, parent) {
        super(tableInfo, parent);
        this.title = document.createElement('select');
        this.title.classList.add('content-main-title');
        this.title.contentEditable = "false";
        this.parent.getAvaliableTableViews().forEach((element, index) => {
            var option = document.createElement('option');
            option.text = element;
            option.value = index.toString();
            this.title.options[index] = option;
            if (this.localizedName == element)
                this.title.selectedIndex = index;
        });
        this.title.onchange = this.selectNewTable.bind(this);
        this.rootelement.insertBefore(this.title, this.rootelement.firstChild);
    }
    selectNewTable(event) {
        this.parent.setOpenTable(event.target.selectedIndex);
    }
}
//# sourceMappingURL=table-view.js.map