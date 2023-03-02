import { globalVariables } from './internal.js';
export class moduleBase {
    constructor(data) {
        this.changelist = [];
        this.htmlElement = document.createElement("div");
        switch (data.coolSize) {
            case 1:
                this.htmlElement.classList.add('col-space-one');
                break;
            case 2:
                this.htmlElement.classList.add('col-space-tow');
                break;
            default:
                this.htmlElement.classList.add('col-space-tree');
                break;
        }
        this.htmlElement.classList.add('growflex');
        this.htmlElement.classList.add('module-main');
        this.title = document.createElement("p");
        if (data.required) {
            var asterisk = document.createElement('b');
            asterisk.style.color = "red";
            asterisk.textContent = ' *';
            this.title.textContent = data.localizedName;
            this.title.appendChild(asterisk);
        }
        else {
            this.title.textContent = data.localizedName;
        }
        this.title.classList.add('module-imput-text');
        this.htmlElement.appendChild(this.title);
        this.data = data;
    }
    OnChange() {
        for (var i = 0; i < this.changelist.length; i++) {
            this.changelist[i]();
        }
    }
    addOnChange(reference) {
        this.changelist[this.changelist.length] = reference;
    }
    getName() {
        return this.data.name;
    }
    getlocalizedName() {
        return this.data.localizedName;
    }
    displayTitle() {
        if (this.title.classList.contains('dontdisplay')) {
            this.title.classList.remove('dontdisplay');
        }
        else
            this.title.classList.add('dontdisplay');
    }
}
export class dataInfo {
}
export class module {
    static new(propriety) {
        return globalVariables.moduleRegistry[propriety.Type](propriety);
    }
}
//# sourceMappingURL=module-base.js.map