import { Butons } from './internal.js';
import { user } from './internal.js';
export class auxiliar {
    static getJSON(url, requestType, callback, body = null) {
        var xhr = new XMLHttpRequest();
        xhr.open(requestType, url, true);
        xhr.setRequestHeader('token', localStorage.getItem("token"));
        xhr.responseType = 'json';
        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.onload = function () {
            var status = xhr.status;
            if (status === 200) {
                callback(xhr.response);
            }
            else if (status === 451) {
                window.location.replace(xhr.getResponseHeader("location"));
            }
            else {
                console.log(status, xhr.response);
            }
        };
        if (body) {
            xhr.send(JSON.stringify(body));
        }
        else {
            xhr.send();
        }
    }
    ;
    static clearView(viewElement, newEntity, newView) {
        Butons.activeFromPermission(user.current.permission[newEntity], newView);
        const content = document.getElementById('div-content');
        while (content.firstChild) {
            content.removeChild(content.lastChild);
        }
        if (newView == globalVariables.enumViews.TABLE) {
            globalVariables.entities[newEntity].tableContent().addTableContent();
            viewElement = globalVariables.entities[newEntity].tableContent().rootelement;
        }
        document.getElementById('div-content').appendChild(viewElement);
        globalVariables.curentEntity = newEntity;
        globalVariables.currentView = newView;
    }
}
class View {
    constructor() {
        this.TABLE = 'table';
        this.ENTITY = 'entity';
    }
}
export class globalVariables {
}
globalVariables.enumViews = new View();
globalVariables.home = "clintescontas";
globalVariables.moduleRegistry = [];
globalVariables.entities = [];
//# sourceMappingURL=auxiliar.js.map