import { globalVariables } from './auxiliar.js';
import { module } from './internal.js';
import { Table } from './internal.js';
import { auxiliar } from './internal.js';
export class entity {
    constructor(name, localizedName, principalPropriety, proprieties) {
        this.proprieties = [];
        this.name = name;
        this.localizedName = localizedName;
        this.principalPropriety = principalPropriety;
        this.table = new Table(proprieties, localizedName);
        this.content = document.createElement('div');
        this.content.classList.add('content-main');
        proprieties.forEach((element) => {
            this.addPropriety(module.new(element.name, element.localizedName, element.Type, element.coolSize));
            this.content.appendChild(this.proprieties[element.name].htmlElement);
        });
    }
    addPropriety(prop) {
        this.proprieties[this.proprieties.length] = this.proprieties[prop.getName()] = prop;
    }
    getName() {
        return this.name;
    }
    getlocalizedName() {
        return this.localizedName;
    }
    setView(id) {
        auxiliar.getJSON("https://localhost:44358/api/Values/" + this.name + "/id?categoryIds=" + id, 'GET', (data) => {
            this.proprieties.forEach(prop => {
                prop.setValue(data[0][prop.name]);
            });
            this.currentview = data["_id"];
        });
    }
    saveView() {
        var json = {};
        this.proprieties.forEach(prop => {
            json[prop.getName()] = prop.getValue();
        });
        auxiliar.getJSON("https://localhost:44358/api/Values/" + this.name, 'PUT', (data) => {
        }, json);
        this.closeView();
    }
    closeView() {
        auxiliar.clearView(this.tableContent().rootelement, this.getName(), globalVariables.enumViews.TABLE);
    }
    clearView() {
        this.proprieties.forEach(prop => {
            prop.clear;
        });
        this.currentview = "";
    }
    viewContent() {
        return this.content;
    }
    tableContent() {
        return this.table;
    }
}
//# sourceMappingURL=entity.js.map