export class auxiliar {
    static getJSON(url, requestType, callback, body = null) {
        var xhr = new XMLHttpRequest();
        xhr.open(requestType, url, true);
        xhr.responseType = 'json';
        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.onload = function () {
            var status = xhr.status;
            if (status === 200) {
                callback(xhr.response);
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
        const content = document.getElementById('div-content');
        while (content.firstChild) {
            content.removeChild(content.lastChild);
        }
        document.getElementById('div-content').appendChild(viewElement);
        globalVariables.curentEntity = newEntity;
        globalVariables.currentView = newView;
    }
}
class View {
}
export class globalVariables {
}
globalVariables.enumViews = new View();
globalVariables.home = "clintescontas";
globalVariables.moduleRegistry = [];
globalVariables.entities = [];
//# sourceMappingURL=auxiliar.js.map