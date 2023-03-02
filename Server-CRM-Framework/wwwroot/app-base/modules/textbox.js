import { moduleBase } from '../internal.js';
import { globalVariables } from '../internal.js';
export class textboxModule extends moduleBase {
    constructor(data) {
        super(data);
        var box = document.createElement("INPUT");
        if (data.image.normalize() === 'no'.normalize()) {
            box.classList.add('module-imput');
        }
        else {
            box.classList.add('module-imput-img');
            box.style.backgroundImage = "url('" + data.image + "')";
        }
        box.setAttribute("type", "text");
        box.id = name;
        this.imput = box;
        this.htmlElement.appendChild(this.imput);
        this.imput.onchange = this.OnChange.bind(this);
    }
    getValue() {
        return this.imput.value;
    }
    setValue(value) {
        this.imput.value = value;
        this.OnChange();
    }
    clear() {
        this.imput.value = "";
    }
    getType() {
        return 'TextBox';
    }
}
document.head.insertAdjacentHTML('beforeend', '<link rel=stylesheet href=app-base/modules/textbox.css>');
globalVariables.moduleRegistry['TextBox'] = (data) => {
    return new textboxModule(data);
};
//# sourceMappingURL=textbox.js.map