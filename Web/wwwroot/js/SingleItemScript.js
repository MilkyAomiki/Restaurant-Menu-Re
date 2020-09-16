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
}


window.onload = function () {
    document.getElementById("turntoedit-button").onclick = swapToEditable;
}