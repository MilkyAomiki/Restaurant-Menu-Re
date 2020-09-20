var addClickEvent = function () {
    document.getElementById('cancel-button').onclick = function () {
        window.location.href = "/menu";
    }
}

window.onload = addClickEvent;