MainFunctionality = {
    addRowClickEvents: function () {
        let rows = document.getElementsByClassName("table-data");

        for (let i = 0; i < rows.length; i++) {
            rows[i].addEventListener('click', function (e) {
                let rowData = e.currentTarget.children;
                let rowId;
                for (let i = 0; i < rowData.length; i++) {
                    if (rowData[i].id == 'id') {
                        rowId = rowData[i].innerText;
                        break;
                    }
                }
                window.location = "/menu/" + rowId;
            }, false);
        }
    },

    orderClickEvents:  function () {
        let ths = document.getElementsByClassName('column-name');

        for (let i = 0; i < ths.length; i++) {
            ths[i].addEventListener('click', function (e) {
                let orc;
                let ort;
                orc = e.currentTarget.getAttribute("id");
                if (orderParams.column == orc) {
                    if (orderParams.type == "asc") {
                        ort = "desc";
                    } else {
                        ort = "asc";
                    }
                } else {
                    ort = "asc";
                }
                orderParams.formerColumn = orderParams.column;
                orderParams.column = orc;
                orderParams.type = ort;

                MainFunctionality.depictSorting();
                MainFunctionality.updateMenu(e.currentTarget);
            });
        }
    },

    depictSorting:  function () {
        let headers = document.getElementsByClassName('column-name');

        if (orderParams.formerColumn != undefined && orderParams.formerColumn != "") {
            document.getElementById(orderParams.formerColumn).getElementsByTagName("img")[0].remove();
        }
        for (let i = 0; i < headers.length; i++) {
            if (headers[i].getAttribute("id") == orderParams.column) {
                if (orderParams.type == 'desc') {
                    headers[i].innerHTML += '<img src="/pics/arrow_drop_down.svg" alt="desc" />';
                } else {
                    headers[i].innerHTML += '<img src="/pics/arrow_drop_up.svg" alt="asc" />';
                }
            }
        }
    },

    insertSearchVal:  function () {
        document.getElementsByClassName("search-bar")[0].firstElementChild.value = searchFileds.titleVal;
        document.getElementsByClassName("search-bar")[1].firstElementChild.value = searchFileds.descrVal;
        document.getElementsByClassName("search-bar")[2].firstElementChild.value = searchFileds.ingredVal;
        document.getElementsByClassName("search-bar")[3].firstElementChild.value = searchFileds.gramsVal;
        document.getElementsByClassName("search-bar")[4].firstElementChild.value = searchFileds.calVal;
        document.getElementsByClassName("search-bar")[5].firstElementChild.value = searchFileds.cookTimeVal;
        document.getElementsByClassName("search-bar")[6].firstElementChild.value = searchFileds.priceVal;
        document.getElementsByClassName("search-bar")[7].firstElementChild.value = searchFileds.createDatVal;

    },

    searchBoxClickEvent:  function () {
        let searchBars = document.getElementsByClassName("search-bar");
        for (let i = 0; i < searchBars.length; i++) {
            searchBars[i].firstElementChild.onkeydown = function (e) {

                if (e.code == 'Enter') {
                    MainFunctionality.updateMenu(undefined);
                }
            }
        }
    },

    updateMenu:  function (orderColumn) {
        let url = '/menu/items?'
        let orderColumnUrl = "";
        let orderTypeUrl = "";
        let searchUrl = "";

        orderColumnUrl = 'orderColumn=' + orderParams.column;
        orderTypeUrl = "&" + 'orderType=' + orderParams.type;

        url += orderColumnUrl + orderTypeUrl;

        let searchBars = document.getElementsByClassName("search-bar");
        for (let i = 0; i < searchBars.length; i++) {
            let searchBar = searchBars[i].firstElementChild;
            if (searchBar.value != '') {
                searchUrl += '&' + searchBar.getAttribute("name") + '=' + searchBar.value;
            }
        }
        if (url == '/menu/items?') {

            searchUrl = searchUrl.slice(1, searchUrl.length);
        }
        url += searchUrl;

        const xhr = new XMLHttpRequest();
        xhr.open("GET", url);
        xhr.send();
        xhr.onreadystatechange = (e) => {
            if (xhr.readyState == 4 && xhr.status == 200) {
                let oldItems = document.getElementById("menu-items-rows");
                oldItems.innerHTML = xhr.response;
                this.addRowClickEvents();
            }
        }

    },

    fireUpAll: function () {
        this.addRowClickEvents();
        document.getElementById('new-item-button').onclick = function () {
            window.location.href = '/menu/new';
        }
        this.orderClickEvents();
        this.depictSorting();
        this.insertSearchVal();
        this.searchBoxClickEvent();
    }

}

window.onload = function () {
    MainFunctionality.fireUpAll();
}