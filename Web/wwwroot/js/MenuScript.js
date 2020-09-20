function addRowClickEvents() {
    var rows = document.getElementsByClassName("table-data");


    for (var i = 0; i < rows.length; i++) {
        rows[i].addEventListener('click', function (e) {
            var rowData = e.currentTarget.children;
            var rowId;
            for (var i = 0; i < rowData.length; i++) {
                if (rowData[i].id == 'id') {
                    rowId = rowData[i].innerText;
                    break;
                }
            }
            window.location = "/menu/" + rowId;
        }, false);
    }
}

const mainFunc = function () {
    addRowClickEvents();
    document.getElementById('new-item-button').onclick = function(){
        window.location.href = '/menu/new';
    }

}

const pageClickEvents = function () {

}
window.onload = mainFunc;
    