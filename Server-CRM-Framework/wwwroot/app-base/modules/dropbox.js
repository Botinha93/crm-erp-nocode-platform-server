import { moduleBase } from '../internal.js';
import { globalVariables } from '../internal.js';
export class DropBoxModule extends moduleBase {
    constructor(data) {
        super(data);
        var content = document.createElement('div');
        content.classList.add('module-dropdown');
        content.onclick = this.drop;
        this.selected = document.createElement('p');
        this.selected.textContent = " ";
        content.appendChild(this.selected);
        var animation = document.createElement('div');
        animation.classList.add('module-dropdown-x');
        content.appendChild(animation);
        this.itemList = document.createElement('ul');
        this.itemList.classList.add('module-dropdown-ul');
        this.itemList.onclick = this.selectitem.bind(this);
        this.itemList.style.display = 'none';
        content.appendChild(this.itemList);
        this.htmlElement.appendChild(content);
        this.data.dataArray.forEach(element => {
            this.addItem(element);
        });
        this.selected.onchange = this.OnChange.bind(this);
    }
    getValue() {
        return this.selected.textContent;
    }
    setValue(value) {
        if (this.data.dataArray.includes(value)) {
            this.selected.textContent = value;
        }
        this.OnChange();
    }
    clear() {
        this.selected.textContent = " ";
    }
    getType() {
        return 'DropBox';
    }
    addItem(item) {
        this.data.dataArray.push(item);
        var newli = document.createElement('li');
        newli.textContent = item;
        this.itemList.appendChild(newli);
    }
    drop(event) {
        event.preventDefault();
        var temp;
        if (event.target.classList.contains('module-dropdown')) {
            temp = event.target.getElementsByClassName('module-dropdown-ul')[0];
        }
        else {
            temp = event.target.parentElement.getElementsByClassName('module-dropdown-ul')[0];
        }
        if (temp && temp.style.display === 'none') {
            temp.style.display = '';
        }
        else if (temp) {
            temp.style.display = 'none';
        }
    }
    selectitem(event) {
        if (event.target.tagName == 'LI') {
            this.setValue(event.target.textContent);
        }
    }
}
window.addEventListener("click", (event) => {
    if (!event.target.matches('.module-dropdown')) {
        var teste = true;
        if (event.target.parentElement) {
            teste = !event.target.parentElement.matches('.module-dropdown');
        }
        if (teste == true) {
            var list = document.getElementsByClassName('module-dropdown-ul');
            for (var i = 0; i < list.length; i++) {
                list[i].style.display = 'none';
            }
        }
    }
});
document.head.insertAdjacentHTML('beforeend', '<link rel=stylesheet href=app-base/modules/dropbox.css>');
globalVariables.moduleRegistry['DropBox'] = (data) => {
    return new DropBoxModule(data);
};
//# sourceMappingURL=dropbox.js.map