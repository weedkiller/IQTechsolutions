function CreateTableRow(tableBody, id) {

    var row = document.createElement("tr");
    row.id = id;
    row.classList.add(id);

    tableBody.append(row);

    return row;
}

function CreateTableColumn(tableRow, id, value) {
    var column = document.createElement("td");
    column.id = id;

    tableRow.append(column);

    return column;
}

function AjaxError(xhr, textStatus, err) {
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