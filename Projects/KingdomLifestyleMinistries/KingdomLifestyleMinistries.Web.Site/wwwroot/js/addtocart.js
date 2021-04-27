/* -------------------------------------------------------------------------------- /
	
	Magentech jQuery
	Created by Magentech
	v1.0 - 20.9.2016
	All rights reserved.
	
/ -------------------------------------------------------------------------------- */


// Cart add remove functions
var cart = {
	'add': function (product_id, quantity) {

		var url = "/Shop/ShoppingCart/AddToCart";

		$.ajax({
			type: "POST",
			data: { id: product_id, qty: quantity },
			url: url,
			success: function (data) {

				if (data.quantity === 1) {

					var markup = "<tr id=\"row_" + data.id + "\">" + 
						"<td><a asp-area=\"Products\" asp-controller=\"Home\" asp-action=\"Details\" asp-route-id=\" " + data.id + "\"><img alt=\"" + data.name + "\" src=\"" + data.imageUrl + "\"></a></td>" +
						"<td><a asp-area=\"Products\" asp-controller=\"Home\" asp-action=\"Details\" asp-route-id=\"" + data.id + "\">" + data.name + "</a></td>" +
						"<td>X <span id=\"qty_" + data.id + "\">" + data.quantity + "</span></td>" +
						"<td>" + data.price + "</td>" +
						"<td><a class=\"close\" href=\"javascript:;\" onclick=\"cart.remove('" + data.id + "');\"><i class=\"fa fa-close font-13\"></i></a></td>" +
						"</tr >";

					$("#ShoppingCartHeaderBody").prepend(markup);
				} else {
					$("#qty_" + data.id).html(data.quantity);
				}

                $('#subTotal').html('R ' + data.sub.toFixed(2));
                $('#vatTotal').html('R ' + data.vat.toFixed(2));
                $('#grandTotal').html('R ' + data.grand.toFixed(2));

				$("#titleTotal").html(data.totalCount);
                alert("Your product has been added to the shoppingcart!");
			},
			error: function (xhr, textStatus, err) {
				alert("An error with the following detials occured : "
					+ "\r\n == readyState: " + xhr.readyState
					+ "\r\n == responseText: " + xhr.responseText
					+ "\r\n == status: " + xhr.status
					+ "\r\n == text status: " + textStatus
					+ "\r\n == error: " + err);
			}
		});
	},

	'remove': function (product_id) {

		$.ajax({
			url: "/Shop/ShoppingCart/Remove",
			datatype: "json",
			data: { id: product_id },
			type: "Get",
			async: true,
			success: function (data) {
				if (data.quantity > 0) {
					document.getElementById("qty_" + data.id).innerHTML = data.quantity;

				} else {

                    document.getElementById("row_" + data.id).innerHTML = "";
                }

				$('#subTotal').html('R ' + data.sub.toFixed(2));
				$('#vatTotal').html('R ' + data.vat.toFixed(2));
				$('#grandTotal').html('R ' + data.grand.toFixed(2));

                $("#titleTotal").html(data.totalCount);
                alert("Your product has been removed from the shoppingcart!");
			},
			error: function (xhr, textStatus, err) {
				alert("An error with the following detials occured : "
					+ "\r\n == readyState: " + xhr.readyState
					+ "\r\n == responseText: " + xhr.responseText
					+ "\r\n == status: " + xhr.status
					+ "\r\n == text status: " + textStatus
					+ "\r\n == error: " + err);
			}
		});
	}
}

var wishlist = {
	'add': function (product_id) {
		
	}
}
var compare = {
	'add': function (product_id) {
		
	}
}
