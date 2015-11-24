document.addEventListener("DOMContentLoaded", function () {
    console.log("DOM loaded and to go !");
    loadMenu();
});

function loadMenu() {
    SpecialModel.getSpecial(setupSpecialTable)
}

function setupSpecialTable(MenuList) {
    console.log(MenuList);
    var MenuTable = document.getElementById("SpecialList");

    for (i = 0; i < MenuList.length; i++) {
        var row = document.createElement("tr");

        var itemNameCol = document.createElement("td");
        itemNameCol.innerHTML = MenuList[i].itemName;
        console.log(MenuList[i].itemName);
        row.appendChild(itemNameCol);

        var itemPriceCol = document.createElement("td");
        itemPriceCol.innerHTML = MenuList[i].itemPrice;
        row.appendChild(itemPriceCol);

        MenuTable.appendChild(row);
    }

}