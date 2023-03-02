import { globalVariables } from '../internal.js';
export class textboxModule {
    constructor(name, localizedName, image = 'no', coolSize) {
        this.changelist = [];
        this.htmlElement = document.createElement("div");
        switch (coolSize) {
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
        this.htmlElement.classList.add('module-main');
        var title = document.createElement("p");
        title.textContent = localizedName;
        title.classList.add('module-imput-text');
        this.htmlElement.appendChild(title);
        var box = document.createElement("INPUT");
        console.log(image);
        if (image.normalize() === 'no'.normalize()) {
            box.classList.add('module-imput');
        }
        else {
            box.classList.add('module-imput-img');
            box.style.backgroundImage = "url('" + image + "')";
        }
        box.setAttribute("type", "text");
        box.id = name;
        this.imput = box;
        this.htmlElement.appendChild(this.imput);
        this.imput.onchange = this.OnChange;
        this.name = name;
        this.localizedName = localizedName;
    }
    OnChange() {
        for (var i = 0; i < this.changelist.length; i++) {
            this.changelist[i]();
        }
    }
    getValue() {
        return this.imput.value;
    }
    setValue(value) {
        this.imput.value = value;
    }
    clear() {
        this.imput.value = "";
    }
    addOnChange(reference) {
        this.changelist[this.changelist.length] = reference;
    }
    getName() {
        return this.name;
    }
    getlocalizedName() {
        return this.localizedName;
    }
    getType() {
        return 'TextBox';
    }
}
document.head.insertAdjacentHTML('beforeend', '<link rel=stylesheet href=app-base/modules/textbox.css>');
globalVariables.moduleRegistry['TextBox'] = (name, localizedName, coolSize = 3, image = 'no') => {
    return new textboxModule(name, localizedName, image, coolSize);
};
//# sourceMappingURL=textbox.js.map