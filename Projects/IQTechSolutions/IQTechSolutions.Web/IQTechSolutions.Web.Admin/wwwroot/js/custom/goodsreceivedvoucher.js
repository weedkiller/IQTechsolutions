function ProcessGoodsReceivedVoucher() {

    var supplierId = ValidateSupplier();
    var date = ValidateDate();

    AddGoodsReceivedVoucherAndProcess(supplierId, date);
}

function CancelGoodsReceivedVoucher() {

    var voucherId = $('#GoodReceivedVoucher_Id').val();

    $.ajax({
        url: "/Inventory/GoodsReceived/RemoveGoodsReceivedVoucher",
        type: "POST",
        dataType: "JSON",
        data: { voucherId: voucherId },
        success: function (data) {
            window.location.href = '/Home/Index';
        },
        error: function (xhr, textStatus, err) {
            AjaxError(xhr, textStatus, err);
        }
    });
}

function OnSelectionProductChanged() {

    var productId = $('#Product option:selected').val();

    if (productId !== null && productId !== "0") {
        $.ajax({
            url: "/Inventory/GoodsReceived/GetProduct",
            type: "POST",
            dataType: "JSON",
            data: { productId: productId },
            success: function (data) {

                $('#UnitPriceToAdd').val(data.excl);
            },
            error: function (xhr, textStatus, err) {
                AjaxError(xhr, textStatus, err);
            }
        });
    }
}

function ShowDeleteGRVProductModel(productId) {

    var voucherId = $('#GoodReceivedVoucher_Id').val();

    $.ajax({
        url: "/Inventory/GoodsReceived/RemoveGoodsReceivedVoucherProduct",
        type: "POST",
        dataType: "JSON",
        data: { voucherId: voucherId, productId: productId },
        success: function (data) {

            var qtyColumn = document.getElementById(`qty_${productId}`);

            if (parseFloat(qtyColumn.innerHTML) > 1) {
                qtyColumn.innerHTML = (parseFloat(qtyColumn.innerHTML) - 1).toFixed(2);

                var exclColumn = document.getElementById("excl_" + productId);
                exclColumn.innerHTML = (parseFloat(exclColumn.innerHTML) - parseFloat(data.excl)).toFixed(2);

                var vatColumn = document.getElementById("vat_" + productId);
                vatColumn.innerHTML = (parseFloat(vatColumn.innerHTML) - parseFloat(data.vat)).toFixed(2);

                var inclColumn = document.getElementById("incl_" + productId);
                inclColumn.innerHTML = (parseFloat(inclColumn.innerHTML) - parseFloat(data.incl)).toFixed(2);
                
            } else {
                var existingTableRow = document.getElementById(`row_${productId}`);
                existingTableRow.parentNode.removeChild(existingTableRow);
            }

            var exclTotalColumn = document.getElementById("tableExclTotal");
            exclTotalColumn.innerHTML = (parseFloat(exclTotalColumn.innerHTML) - parseFloat(data.excl)).toFixed(2);

            var vatTotalColumn = document.getElementById("tableVatTotal");
            vatTotalColumn.innerHTML = (parseFloat(vatTotalColumn.innerHTML) - parseFloat(data.vat)).toFixed(2);

            var inclTotalColumn = document.getElementById("tableInclTotal");
            inclTotalColumn.innerHTML = (parseFloat(inclTotalColumn.innerHTML) - parseFloat(data.incl)).toFixed(2);
        },
        error: function (xhr, textStatus, err) {
            AjaxError(xhr, textStatus, err);
        }
    });
}

function ProcessGoodsReceivedVoucherProductAddition() {

    var voucherId = $('#GoodReceivedVoucher_Id').val();

    var supplierId = ValidateSupplier();
    var date = ValidateDate();

    if (supplierId === undefined || date === undefined)
        return; 

    $.ajax({
        url: "/Inventory/GoodsReceived/GetGoodsReceivedVoucher",
        type: "POST",
        dataType: "JSON",
        data: { voucherId: voucherId, supplierId: supplierId, date: date},
        success: function (data) {
            AddUpdateGoodsReceivedVoucherProduct(data.id);
        },
        error: function (xhr, textStatus, err) {
            AjaxError(xhr, textStatus, err);
        }
    });
}

function AddUpdateGoodsReceivedVoucherProduct(voucherId) {

    const productId = ValidateProduct();
    const quantity = ValidateQty();
    const unitPrice = ValidateUnitPrice();

    if (productId === undefined || quantity === undefined || unitPrice === undefined)
        return; 

    $.ajax({
        url: "/Inventory/GoodsReceived/AddUpdateGoodsReceivedVoucherProduct",
        type: "POST",
        dataType: "JSON",
        data: { voucherId: voucherId, productId: productId, qty: quantity, priceExcl: unitPrice },
        success: function (data) {
            var existingTableRow = document.getElementById(`row_${data.id}`);

            if (existingTableRow === null) {

                AddGRVDetailsRow(data.id, data.qty, data.name, data.pack, data.excl, data.vat, data.incl);

            } else {

                EditGRVDetailsRow(data.id, data.qty, data.excl, data.vat, data.incl);

            }

            var exclTotalColumn = document.getElementById("tableExclTotal");
            exclTotalColumn.innerHTML = (parseFloat(exclTotalColumn.innerHTML) + (data.qty * data.excl)).toFixed(2);

            var vatTotalColumn = document.getElementById("tableVatTotal");
            vatTotalColumn.innerHTML = (parseFloat(vatTotalColumn.innerHTML) + (data.qty * data.vat)).toFixed(2);

            var inclTotalColumn = document.getElementById("tableInclTotal");
            inclTotalColumn.innerHTML = (parseFloat(inclTotalColumn.innerHTML) + (data.qty * data.incl)).toFixed(2);

            $('#Product').val(0).change();
            $('#QtyToAdd').val(1);
            $('#UnitPriceToAdd').val("");
        },
        error: function (xhr, textStatus, err) {
            AjaxError(xhr, textStatus, err);
        }
    });
}

function AddGRVDetailsRow(id, qty, name, pack, excl, vat, incl) {

    const tableBody = document.getElementById("GoodsReceivedVoucherDetailsBody");

    const tableRow = CreateTableRow(tableBody, `row_${id}`);

    const tableIdColumn = CreateTableColumn(tableRow, `id_${id}`);
    tableIdColumn.style.display = 'none';
    tableIdColumn.innerHTML = id;

    const tableQtyColumn = CreateTableColumn(tableRow, `qty_${id}`);
    tableQtyColumn.innerHTML = qty.toFixed(2);

    const tableNameColumn = CreateTableColumn(tableRow, `name_${id}`);
    tableNameColumn.innerHTML = name;

    const tablePackColumn = CreateTableColumn(tableRow, `pack_${id}`);
    tablePackColumn.innerHTML = pack;

    const tablePriceUnitColumn = CreateTableColumn(tableRow, `unit_${id}`);
    tablePriceUnitColumn.innerHTML = excl.toFixed(2);

    const tablePriceExclColumn = CreateTableColumn(tableRow, `excl_${id}`);
    tablePriceExclColumn.innerHTML = (qty * excl).toFixed(2);

    const tableVatColumn = CreateTableColumn(tableRow, `vat_${id}`);
    tableVatColumn.innerHTML = (qty * vat).toFixed(2);

    const tablePriceInclColumn = CreateTableColumn(tableRow, `incl_${id}`);
    tablePriceInclColumn.innerHTML = (qty * incl).toFixed(2);;

    const tableButtonColumn = CreateTableColumn(tableRow, `btnDelete_${id}`);

    const tableProductDeleteButton = document.createElement("a");
    tableProductDeleteButton.href = "javascript:;";
    tableProductDeleteButton.onclick = function () { ShowDeleteGRVProductModel(id) };
    tableButtonColumn.append(tableProductDeleteButton);

    const tableProductDeleteButtonIcon = document.createElement("i");
    tableProductDeleteButtonIcon.classList.add("fa", "fa-trash");
    tableProductDeleteButton.append(tableProductDeleteButtonIcon);
}

function EditGRVDetailsRow(id, qty, excl, vat, incl) {

    var qtyColumn = document.getElementById("qty_" + id);
    qtyColumn.innerHTML = (parseInt(qtyColumn.innerHTML) + qty).toFixed(2);

    var exclColumn = document.getElementById("excl_" + id);
    exclColumn.innerHTML = (parseFloat(exclColumn.innerHTML) + (qty * excl)).toFixed(2);

    var vatColumn = document.getElementById("vat_" + id);
    vatColumn.innerHTML = (parseFloat(vatColumn.innerHTML) + (qty * vat)).toFixed(2);

    var inclColumn = document.getElementById("incl_" + id);
    inclColumn.innerHTML = (parseFloat(inclColumn.innerHTML) + (qty * incl)).toFixed(2);
}

function ValidateSupplier() {
    var e = $('#Supplier option:selected').val();
    if (e === null || e === '0') {
        alert("Please select a supplier");
        return undefined;
    }
    return e;
}

function ValidateDate() {
    var d = $('#date').val();
    if (d === null || d === '') {
        alert("Please select a date");
        return undefined;
    }
    return d;
}

function ValidateQty() {
    var e = $('#QtyToAdd').val();
    if (e === null || e === '0') {
        alert("Please select a supplier");
        return undefined;
    }
    return e;
}

function ValidateProduct() {
    var e = $('#Product option:selected').val();
    if (e === null || e === "0") {
        alert("Please select a Product");
        return undefined;
    }
    return e;
}

function ValidateUnitPrice() {
    var e = $('#UnitPriceToAdd').val();
    if (e === null || e === '0') {
        alert("Please enter the unit price");
        return undefined;
    }
    return e;
}