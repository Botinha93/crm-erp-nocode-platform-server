export class topmenubuntons {
    constructor(imgBase64, text, action, filter = "") {
        var newli = document.createElement('li');
        var newlidropdown = document.createElement('li');
        newli.textContent = text;
        newli.style.background = "url('" + imgBase64 + "')";
        newli.style.filter = filter;
        newli.onclick = action;
        newlidropdown.textContent = text;
        newlidropdown.style.background = "url('" + imgBase64 + "')";
        newlidropdown.onclick = action;
        newli.classList.add('nav-bar-menu-item');
        newli.id = text;
        newlidropdown.classList.add('nav-bar-dropmenu-item');
        newlidropdown.id = 'nav-bar-dropmenu-item-' + text;
        document.getElementById('nav-bar-menu').appendChild(newli);
        document.getElementById('nav-bar-dropmenu').appendChild(newlidropdown);
    }
    static clear() {
        document.getElementById('nav-bar-menu').innerHTML = '';
        document.getElementById('nav-bar-dropmenu').innerHTML = '';
    }
    static detectWrap() {
        var warped = false;
        var items = document.getElementsByClassName('nav-bar-menu-item');
        var top = items[0].getBoundingClientRect().top;
        for (var i = 0; i < items.length; i++) {
            if (top < items[i].getBoundingClientRect().top) {
                warped = true;
                document.getElementById('nav-bar-dropmenu-item-' + items[i].id).style.display = 'list-item';
            }
            else {
                document.getElementById('nav-bar-dropmenu-item-' + items[i].id).style.display = 'none';
            }
        }
        ;
        if (warped) {
            document.getElementById('nav-bar-dropmenu-buttom').style.display = 'block';
        }
        else {
            document.getElementById('nav-bar-dropmenu-buttom').style.display = 'none';
        }
    }
}
//# sourceMappingURL=topmenubuntons.js.map