var rows = [];

function AddProductToTable() {

    var url = "/Inventory/GoodsReceived/AddGoodsReceivedProduct";
    var identity = $('#Product option:selected').val();
    var quantity = $('#QtyToAdd').val();

    if (quantity === "0") {
        alert("You cannot accept 0 Products!");
    }
    if (identity === "0") {
        alert("Please select a Product!");
    }


    if (identity !== "0") {
        $.ajax({
            url: url,
            type: "GET",
            dataType: "JSON",
            data: { id: identity, qty: quantity },
            success: function (data) {

                var existingTableRow = document.getElementById("row_" + data.id);

                if (existingTableRow === null) {
                    var tableBody = document.getElementById("GoodsReceivedVoucherDetailsBody");

                    var tableRow = document.createElement("tr");

                    var tableIdColumn = document.createElement("td");
                    var tableQtyColumn = document.createElement("td");
                    var tableNameColumn = document.createElement("td");
                    var tablePackColumn = document.createElement("td");
                    var tablePriceUnitColumn = document.createElement("td");
                    var tablePriceExclColumn = document.createElement("td");
                    var tableVatColumn = document.createElement("td");
                    var tablePriceInclColumn = document.createElement("td");

                    var tableButtonColumn = document.createElement("td");

                    var tableProductDeleteButton = document.createElement("a");
                    var tableProductDeleteButtonIcon = document.createElement("i");

                    tableBody.append(tableRow);

                    tableRow.append(tableIdColumn);
                    tableRow.append(tableQtyColumn);
                    tableRow.append(tableNameColumn);
                    tableRow.append(tablePackColumn);
                    tableRow.append(tablePriceUnitColumn);
                    tableRow.append(tablePriceExclColumn);
                    tableRow.append(tableVatColumn);
                    tableRow.append(tablePriceInclColumn);
                    tableRow.append(tableButtonColumn);

                    tableButtonColumn.append(tableProductDeleteButton);
                    tableProductDeleteButton.append(tableProductDeleteButtonIcon);

                    tableRow.id = "row_" + data.id;
                    tableRow.classList.add("row_" + data.id);

                    tableIdColumn.id = "id_" + data.id;
                    tableIdColumn.style.display = 'none';
                    tableIdColumn.innerHTML = data.id;

                    tableQtyColumn.id = "qty_" + data.id;
                    tableQtyColumn.innerHTML = data.qty;

                    tableNameColumn.id = "name_" + data.id;
                    tableNameColumn.innerHTML = data.name;

                    tablePackColumn.id = "pack_" + data.id;
                    tablePackColumn.innerHTML = data.pack;

                    tablePriceUnitColumn.id = "unit_" + data.id;
                    tablePriceUnitColumn.innerHTML = data.excl.toFixed(2);;

                    tablePriceExclColumn.id = "excl_" + data.id;
                    tablePriceExclColumn.innerHTML = (data.qty * data.excl).toFixed(2);;

                    tableVatColumn.id = "vat_" + data.id;
                    tableVatColumn.innerHTML = (data.qty * data.vat).toFixed(2);;

                    tablePriceInclColumn.id = "incl_" + data.id;
                    tablePriceInclColumn.innerHTML = (data.qty * data.incl).toFixed(2);;

                    tableProductDeleteButton.href = "javascript:;";
                    tableProductDeleteButton.onclick = function () { ShowDeleteGRVProductModel(data.id) };

                    tableProductDeleteButtonIcon.classList.add("fa", "fa-trash");
                } else {
                    var qtyColumn = document.getElementById("qty_" + data.id);
                    qtyColumn.innerHTML = parseInt(qtyColumn.innerHTML) + data.qty;

                    var exclColumn = document.getElementById("excl_" + data.id);
                    exclColumn.innerHTML =
                        (parseFloat(exclColumn.innerHTML) + (data.qty * data.excl)).toFixed(2);

                    var vatColumn = document.getElementById("vat_" + data.id);
                    vatColumn.innerHTML = (parseFloat(vatColumn.innerHTML) + (data.qty * data.vat)).toFixed(2);

                    var inclColumn = document.getElementById("incl_" + data.id);
                    inclColumn.innerHTML =
                        (parseFloat(inclColumn.innerHTML) + (data.qty * data.incl)).toFixed(2);
                }

                var exclTotalColumn = document.getElementById("tableExclTotal");
                exclTotalColumn.innerHTML =
                    (parseFloat(exclTotalColumn.innerHTML) + (data.qty * data.excl)).toFixed(2);

                var vatTotalColumn = document.getElementById("tableVatTotal");
                vatTotalColumn.innerHTML =
                    (parseFloat(vatTotalColumn.innerHTML) + (data.qty * data.vat)).toFixed(2);

                var inclTotalColumn = document.getElementById("tableInclTotal");
                inclTotalColumn.innerHTML =
                    (parseFloat(inclTotalColumn.innerHTML) + (data.qty * data.incl)).toFixed(2);

            },
            error: function (xhr, textStatus, err) {
                alert("An error with the following detials occured : " +
                    "\r\n == readyState: " +
                    xhr.readyState +
                    "\r\n == responseText: " +
                    xhr.responseText +
                    "\r\n == status: " +
                    xhr.status +
                    "\r\n == text status: " +
                    textStatus +
                    "\r\n == error: " +
                    err);
            }
        });
    }
}