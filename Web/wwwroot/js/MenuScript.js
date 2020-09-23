function addRowClickEvents() {
    let rows = document.getElementsByClassName("table-data");


    for (var i = 0; i < rows.length; i++) {
        rows[i].addEventListener('click', function (e) {
            let rowData = e.currentTarget.children;
            let rowId;
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
//TODO Sort out orderClick and searchBoxClick functions
function orderClickEvents() {
    let ths = document.getElementsByClassName('column-name');

    for (var i = 0; i < ths.length; i++) {
        ths[i].addEventListener('click', function (e) {
            let orderType = "asc";
            let paramsArr = orderParams.split("-");
            if (paramsArr.length == 2 && paramsArr[0] == e.currentTarget.textContent.toLowerCase().replace(" ", "") && paramsArr[1] == "asc") {
                orderType = "desc";
            }
            window.location.href = 'menu?' + 'orderColumn=' + e.currentTarget.textContent + "&" + 'orderType=' + orderType;
        });
    }
}

function depictSorting() {
    let orderParamsArr = orderParams.split("-");
    let ths = document.getElementsByClassName('column-name');

    for (var i = 0; i < ths.length; i++) {
        if (ths[i].textContent.toLowerCase().replace(" ", "") == orderParamsArr[0]) {
            if (orderParamsArr[1] == 'desc') {
                ths[i].innerHTML += '<img src="/pics/arrow_drop_down.svg" alt="desc" />';
            } else {
                ths[i].innerHTML += '<img src="/pics/arrow_drop_up.svg" alt="asc" />';
            }
        }

        
    }
}

function searchBoxClickEvent() {
    let searchBars = document.getElementsByClassName("search-bar");
    for (var i = 0; i < searchBars.length; i++) {
        searchBars[i].firstElementChild.onkeydown = function (e) {
            let url = '/menu?'
            if (e.code == 'Enter') {
                for (var i = 0; i < searchBars.length; i++) {
                    let searchBar = searchBars[i].firstElementChild;
                    if (searchBar.value != '') {
                        url += searchBar.getAttribute("name") + '=' + searchBar.value + '&';
                    }
                }
                url = url.slice(0, -1);
                window.location.href = url;
            }
        }
    }
}

const mainFunc = function () {
    addRowClickEvents();
    document.getElementById('new-item-button').onclick = function(){
        window.location.href = '/menu/new';
    }
    orderClickEvents();
    depictSorting();
    searchBoxClickEvent();
}

window.onload = mainFunc;
    