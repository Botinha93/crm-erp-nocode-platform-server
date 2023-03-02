import { globalVariables } from './internal.js';
import { auxiliar } from './internal.js';
var pos = [];
document.head.insertAdjacentHTML('beforeend', '<link rel=stylesheet href=theme/basetable.css>');
export class Table {
    constructor(header, title) {
        console.log(header);
        this.table = document.createElement('table');
        this.table.classList.add('generic-table');
        this.thead = this.table.createTHead();
        this.tbody = this.table.createTBody();
        var hrow = this.table.tHead.insertRow(0);
        var counter = 0;
        header.forEach(element => {
            var cell = hrow.insertCell(counter);
            pos[counter] = false;
            console.log(pos[counter]);
            counter++;
            cell.innerHTML = element.localizedName;
            cell.dataset.name = element.name;
            cell.onclick = this.sortTable;
        });
        this.rootelement = document.createElement('div');
        this.rootelement.classList.add('content-main-table');
        var h2 = document.createElement('h2');
        h2.classList.add('content-main-title');
        h2.textContent = title;
        this.rootelement.appendChild(h2);
        var searchel = document.createElement('input');
        searchel.type = "text";
        searchel.classList.add('generic-table-search');
        searchel.onkeyup = this.search;
        searchel.placeholder = "Search for...";
        searchel.title = "Type something to search";
        this.rootelement.appendChild(searchel);
        this.rootelement.appendChild(this.table);
    }
    addTableContent(table) {
        this.tbody.innerHTML = "";
        table.forEach(element => {
            this.addItemContent(element);
        });
    }
    addItemContent(item) {
        var crow = this.tbody.insertRow();
        for (var i = 0; i < this.thead.rows[0].cells.length; i++) {
            var ccel = crow.insertCell();
            ccel.innerText = item[this.thead.rows[0].cells[i].dataset.name];
            ccel.dataset.name = this.thead.rows[0].cells[i].dataset.name;
        }
        crow.ondblclick = () => {
            if (globalVariables.currentView == globalVariables.enumViews.TABLE) {
                globalVariables.entities[globalVariables.curentEntity].setView(item["_id"]);
                auxiliar.clearView(globalVariables.entities[globalVariables.curentEntity].viewContent(), globalVariables.curentEntity, globalVariables.enumViews.ENTITY);
            }
        };
    }
    search(event) {
        var input, filter, table, tr, td, i, txtValue;
        input = event.target;
        filter = input.value.toUpperCase();
        table = event.target.nextElementSibling;
        tr = table.getElementsByTagName("tr");
        for (i = 0; i < tr.length; i++) {
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
//# sourceMappingURL=table-base.js.map