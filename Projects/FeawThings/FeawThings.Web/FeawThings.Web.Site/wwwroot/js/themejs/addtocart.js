/* -------------------------------------------------------------------------------- /
	
	Magentech jQuery
	Created by Magentech
	v1.0 - 20.9.2016
	All rights reserved.
	
/ -------------------------------------------------------------------------------- */


	// Cart add remove functions
	var cart = {
		'add': function(product_id, quantity) {
            $.ajax({
                type: "POST",
				data: { id: product_id },
				url: "/Shop/ShoppingCart/AddToCart",
                success: function (data) {
                    addProductNotice("Product added to Cart", "<img src='" + data.imageUrl + "' alt='" + data.name + "'>", "<h3><a asp-area='Products' asp-controller='Home' asp-action='Details' asp-route-id='" + data.id + "'>" + data.name + "</a> added to <a asp-area='Shop' asp-controller='ShoppingCart' asp-action='Index'>shopping cart</a>!</h3>", "success");

                    var markup = "<tr id='row_" + data.id + "' class='" + data.id + "'>"
                        +"< td class='text-center' style = 'width: 70px' >"
                        + "<a asp-area='Products' asp-controller='Home' asp-action='Details' asp-route-id='" + data.id + "'> <img src='" + data.imageUrl + "' style='width: 70px' alt='" + data.name + "' title='" + data.name + "' class='preview'> </a>"
                        +"</td>"
                        + "<td class='text-left'> <a class='cart_product_name' asp-area='Products' asp-controller='Home' asp-action='Details' asp-route-id='" + data.id + "'>" + data.name + "</a> </td>"
                        + "<td class='text-center'> x " + data.quantity + " </td>"
                        + "<td class='text-center'> " + data.name + " </td>"
                        +"<td class='text-right'>"
                        + "<a asp-area='Products' asp-controller='Home' asp-action='Details' asp-route-id='" + data.id + "' class='fa fa-edit'></a>"
                        +"</td>"
                        +"<td class='text-right'>"
                        + "<a onclick='cart.remove('" + data.id + "');' class='fa fa-times fa-delete'></a>"
                        +"</td>"
                        +"</tr >";

                    $("#ShoppingCartHeaderBody").append(markup);
                    $("#cartHeaderTotalDisplay").replaceWith("<p class='text - shopping - cart cart - total - full' id='cartHeaderTotalDisplay'>" + data.totalCount + " item(s) - " + data.grand + " </p>");
                    $("#subTotal").replaceWith("<td class='text - right' id='subtotal'>" + data.sub +"</td>");
                    $("#transportTotal").replaceWith("<td class='text - right' id='transportTotal'>R0.00</td>");
                    $("#vatTotal").replaceWith("<td class='text - right' id='vatTotal'>" + data.vat + "</td>");
                    $("#grandTotal").replaceWith("<td class='text - right' id='grandTotal'>" + data.grand + "</td>");
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
        $.ajax({
            type: "POST",
            data: { id: product_id },
            url: "/Shop/Wishlist/AddToWishlist",
            success: function (data) {
                addProductNotice("Product added to Wish list",
                    "<img src='" + data.imageUrl + "' alt='" + data.name + "'>",
                    "<h3><a asp-area='Products' asp-controller='Home' asp-action='Details' asp-route-id='" +
                    data.id +
                    "'>" +
                    data.name +
                    "</a> added to <a asp-area='Shop' asp-controller='Wishlist' asp-action='Index'>wish list</a>!</h3>",
                    "success");
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
var compare = {
    'add': function (product_id) {
        $.ajax({
            type: "POST",
            data: { id: product_id },
            url: "/Shop/Compare/Add",
            success: function (data) {
                addProductNotice("Product added to compare",
                    "<img src='" + data.imageUrl + "' alt='" + data.name + "'>",
                    "<h3><a asp-area='Products' asp-controller='Home' asp-action='Details' asp-route-id='" +
                    data.id +
                    "'>" +
                    data.name +
                    "</a> added to <a asp-area='Shop' asp-controller='Compare' asp-action='Index'>product comparison</a>!</h3>",
                    "success");
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

	/* ---------------------------------------------------
		jGrowl – jQuery alerts and message box
	-------------------------------------------------- */
	function addProductNotice(title, thumb, text, type) {
		$.jGrowl.defaults.closer = false;
		//Stop jGrowl
		//$.jGrowl.defaults.sticky = true;
		var tpl = thumb + '<h3>'+text+'</h3>';
		$.jGrowl(tpl, {		
			life: 4000,
			header: title,
			speed: 'slow',
			theme: type
		});
}

function ConfirmAddToCart(id) {

	var url = "/Shop/ShoppingCart/AddToCart";

    $.ajax({
        type: "POST",
        data: { id: id },
        url: url,
        success: function (data) {

            var markup = "<tr id='row_" + data.id + " class='row_" + data.id + "''>" +
				"<td>" + data.quantity + "</td>" +
				"<td>" + data.name + "</td>";

			$("#ShoppingCartHeaderBody").append(markup);
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

