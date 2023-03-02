import { globalVariables } from './internal.js';
import { auxiliar } from './internal.js';
var pos = [];
document.head.insertAdjacentHTML('beforeend', '<link rel=stylesheet href=theme/basetable.css>');
export class Table {
    constructor(tableInfo, parent) {
        this.selectedItens = [];
        this.localizedName = tableInfo.localizedName;
        this.parent = parent;
        this.name = tableInfo.name;
        this.table = document.createElement('table');
        this.table.classList.add('generic-table');
        this.thead = this.table.createTHead();
        this.tbody = this.table.createTBody();
        var hrow = this.table.tHead.insertRow(0);
        var counter = 0;
        tableInfo.display.forEach(element => {
            var cell = hrow.insertCell(counter);
            pos[counter] = false;
            counter++;
            cell.innerHTML = this.parent.getPropriety(element).getlocalizedName();
            cell.dataset.name = this.parent.getPropriety(element).getName();
            cell.onclick = this.sortTable;
        });
        this.rootelement = document.createElement('div');
        this.rootelement.classList.add('content-main-table');
        this.searchel = document.createElement('input');
        this.searchel.type = "text";
        this.searchel.classList.add('generic-table-search');
        this.searchel.onkeyup = this.search;
        this.searchel.placeholder = "Search for...";
        this.searchel.title = "Type something to search";
        this.rootelement.appendChild(this.searchel);
        this.rootelement.appendChild(this.table);
    }
    getName() {
        return this.name;
    }
    getlocalizedName() {
        return this.localizedName;
    }
    toggleSearch() {
        if (this.searchel.style.display == 'none') {
            this.searchel.style.display = 'block';
        }
        else
            this.searchel.style.display = 'none';
    }
    addTableContent() {
        auxiliar.getJSON("api/Values/" + this.parent.getName() + "/tables/" + this.getName(), 'GET', (data) => {
            this.tbody.innerHTML = "";
            data.forEach(element => {
                this.addItemContent(element);
            });
        });
    }
    addItemContent(item) {
        var crow = this.tbody.insertRow();
        for (var i = 0; i < this.thead.rows[0].cells.length; i++) {
            var ccel = crow.insertCell();
            ccel.innerText = item[this.thead.rows[0].cells[i].dataset.name];
            ccel.dataset.name = this.thead.rows[0].cells[i].dataset.name;
        }
        crow.dataset._id = item["_id"];
        crow.onclick = this.handleSelection.bind(this);
        crow.ondblclick = () => {
            if (globalVariables.currentView == globalVariables.enumViews.TABLE) {
                globalVariables.entities[globalVariables.curentEntity].setView(item["_id"]);
                auxiliar.clearView(globalVariables.entities[globalVariables.curentEntity].viewContent(), globalVariables.curentEntity, globalVariables.enumViews.ENTITY);
            }
        };
    }
    handleSelection(event) {
        var target = event.target.parentElement;
        event.preventDefault();
        if (event.ctrlKey) {
            target.classList.add('generic-table-selected');
            this.selectedItens.push(target);
        }
        else if (event.shiftKey) {
            if (this.selectedItens.length < 1) {
                (target).classList.add('generic-table-selected');
                this.selectedItens.push(target);
            }
            else {
                while (this.selectedItens[this.selectedItens.length - 1].getBoundingClientRect().top > (target).getBoundingClientRect().top) {
                    this.selectedItens[this.selectedItens.length - 1].previousElementSibling.classList.add('generic-table-selected');
                    this.selectedItens.push(this.selectedItens[this.selectedItens.length - 1].previousElementSibling);
                }
                while (this.selectedItens[this.selectedItens.length - 1].getBoundingClientRect().top < (target).getBoundingClientRect().top) {
                    this.selectedItens[this.selectedItens.length - 1].nextElementSibling.classList.add('generic-table-selected');
                    this.selectedItens.push(this.selectedItens[this.selectedItens.length - 1].nextElementSibling);
                }
            }
        }
        else {
            while (this.selectedItens.length >= 1) {
                this.selectedItens.pop().classList.remove('generic-table-selected');
            }
            (target).classList.add('generic-table-selected');
            this.selectedItens.push(target);
        }
    }
    search(event) {
        var input, filter, table, tr, td, i, txtValue;
        input = event.target;
        filter = input.value.toUpperCase();
        table = event.target.nextElementSibling;
        tr = table.getElementsByTagName("tr");
        for (i = 1; i < tr.length; i++) {
            td = tr[i].getElementsByTagName("td");
            for (var j = 0; j < td.length; j++) {
                if (td[j]) {
                    txtValue = td[j].textContent || td[j].innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                        break;
                    }
                    else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
    }
    sortTable(event) {
        console.log(pos);
        var table, rows, switching, i, x, y, shouldSwitch;
        table = event.target.parentElement.parentElement.parentElement.tBodies[0];
        switching = true;
        while (switching) {
            switching = false;
            rows = table.rows;
            for (i = 0; i < (rows.length - 1); i++) {
                shouldSwitch = false;
                x = rows[i].getElementsByTagName("TD")[event.target.cellIndex];
                y = rows[i + 1].getElementsByTagName("TD")[event.target.cellIndex];
                if (pos[event.target.cellIndex])
                    if (pos[event.target.cellIndex] && x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                        shouldSwitch = true;
                        break;
                    }
                if (!pos[event.target.cellIndex] && x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            }
            if (shouldSwitch) {
                rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                switching = true;
            }
        }
        pos[event.target.cellIndex] = !pos[event.target.cellIndex];
    }
}
export class tableModel {
}
//# sourceMappingURL=table-base.js.map