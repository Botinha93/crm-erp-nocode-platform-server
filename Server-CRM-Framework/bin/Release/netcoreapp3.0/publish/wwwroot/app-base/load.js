import { entity } from './entity.js';
import { auxiliar } from './internal.js';
import { addDefaultButons } from './internal.js';
import { globalVariables } from './internal.js';
var activeElementSideMenu = document.createElement('li');
export function loadingProcess() {
    function entityClick(event) {
        activeElementSideMenu.classList.remove('side-menu-li-active');
        activeElementSideMenu = event.target;
        activeElementSideMenu.classList.add('side-menu-li-active');
        auxiliar.getJSON("https://localhost:44358/api/Values/" + event.target.dataset.name, 'GET', (data) => {
            globalVariables.entities[event.target.dataset.name].tableContent().addTableContent(data);
            auxiliar.clearView(globalVariables.entities[event.target.dataset.name].tableContent().rootelement, event.target.dataset.name, globalVariables.enumViews.TABLE);
        });
    }
    auxiliar.getJSON('app-base/entitylist.json', 'GET', function (data) {
        var lenght = data['entities'].length;
        for (var i = 0; i < lenght; i++) {
            var li = document.createElement("li");
            li.onclick = entityClick;
            li.classList.add('side-menu-li');
            li.dataset.name = data['entities'][i].name;
            li.innerHTML = data['entities'][i].localizedName;
            li.style.backgroundImage = "url('" + data['entities'][i].image + "')";
            document.getElementById('side-menu').appendChild(li);
            globalVariables.entities[data['entities'][i].name] = new entity(data['entities'][i].name, data['entities'][i].localizedName, data['entities'][i].principalPropriety, data['entities'][i].proprieties);
        }
    });
    addDefaultButons();
}
loadingProcess();
//# sourceMappingURL=load.js.map