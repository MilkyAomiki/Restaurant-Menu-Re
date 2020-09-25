const swapToEditable = function() {
    const readonlyFields = document.getElementById('readonly-fields');
    const editableFields = document.getElementById('hidden-markup').innerHTML;

    document.getElementById('hidden-markup').innerHTML = '';

    document.getElementById('hidden-markup').appendChild(readonlyFields);
    document.getElementById('visible-markup').innerHTML = editableFields;

    document.getElementById("turntoreadonly-button").onclick = swapToReadonly;
}

const swapToReadonly = function () {
    const readonlyFields = document.getElementById('hidden-markup').innerHTML;
    const editableFields = document.getElementById('editable-fields');

    document.getElementById('hidden-markup').innerHTML = '';

    document.getElementById('hidden-markup').appendChild(editableFields);
    document.getElementById('visible-markup').innerHTML = readonlyFields;

    document.getElementById("turntoedit-button").onclick = swapToEditable;
    assignDeleteClick();
}

const assignDeleteClick = function () {
    document.getElementById("delete-button").onclick = function () {
        if (!window.confirm("Are you sure you want to delete this item?")) {
            return;
        }
        let xhr = new XMLHttpRequest();
        let id = document.getElementById("delete-button").getAttribute('value');
        xhr.open('post', '/menu/delete');
        xhr.setRequestHeader("Content-Type", 'application/x-www-form-urlencoded')
        xhr.send('id=' + id);
        xhr.onload = function () {
            window.location.replace('/menu');

        };
    };
}

window.onload = function () {
    document.getElementById("turntoedit-button").onclick = swapToEditable;
    assignDeleteClick();

}