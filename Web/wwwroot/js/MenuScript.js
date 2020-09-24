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
            collectParamsAndReload(e.currentTarget);
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

function insertSearchVal() {
    document.getElementsByClassName("search-bar")[0].firstElementChild.value = titleVal;
    document.getElementsByClassName("search-bar")[1].firstElementChild.value = descrVal;
    document.getElementsByClassName("search-bar")[2].firstElementChild.value = ingredVal;
    document.getElementsByClassName("search-bar")[3].firstElementChild.value = gramsVal;
    document.getElementsByClassName("search-bar")[4].firstElementChild.value = calVal;
    document.getElementsByClassName("search-bar")[5].firstElementChild.value = cookTimeVal;
    document.getElementsByClassName("search-bar")[6].firstElementChild.value = priceVal;
    document.getElementsByClassName("search-bar")[7].firstElementChild.value = createDatVal;

}

function searchBoxClickEvent() {
    let searchBars = document.getElementsByClassName("search-bar");
    for (var i = 0; i < searchBars.length; i++) {
        searchBars[i].firstElementChild.onkeydown = function (e) {
          
            if (e.code == 'Enter') {
                collectParamsAndReload(undefined);
            }
        }
    }
}

function collectParamsAndReload(orderColumn) {
    let url = '/menu?'
    let orderColumnUrl ="";
    let orderType;
    let orderTypeUrl = "";
    let searchUrl = "";
    let paramsArr = orderParams.split("-");
    if (orderColumn != undefined) {
        orderType = "asc";
        if (paramsArr.length == 2 && paramsArr[0] == orderColumn.textContent.toLowerCase().replace(" ", "") && paramsArr[1] == "asc") {
            orderType = "desc";
        }
        orderColumnUrl = 'orderColumn=' + orderColumn.textContent;
        orderTypeUrl = "&" + 'orderType=' + orderType;

       //window.location.href = 'menu?' + 'orderColumn=' + e.currentTarget.textContent + "&" + 'orderType=' + orderType;

    } else {

        if (paramsArr.length == 2 && paramsArr[0] != "" && paramsArr[1] != "") {
            orderColumnUrl = paramsArr[0];
            orderType = paramsArr[1];

            orderColumnUrl = 'orderColumn=' + paramsArr[0];
            orderTypeUrl = "&" + 'orderType=' + orderType;

        }
    }
    url += orderColumnUrl + orderTypeUrl;

    let searchBars = document.getElementsByClassName("search-bar");
        for (var i = 0; i < searchBars.length; i++) {
            let searchBar = searchBars[i].firstElementChild;
            if (searchBar.value != '') {
                searchUrl += '&' + searchBar.getAttribute("name") + '=' + searchBar.value;
            }
        }
        if (url == '/menu?') {

            searchUrl = searchUrl.slice(1, searchUrl.length);
        }
        url += searchUrl;

    window.location.href = url;

}


const mainFunc = function () {
    addRowClickEvents();
    document.getElementById('new-item-button').onclick = function(){
        window.location.href = '/menu/new';
    }
    orderClickEvents();
    depictSorting();
    insertSearchVal();
    searchBoxClickEvent();
}

window.onload = mainFunc;
    