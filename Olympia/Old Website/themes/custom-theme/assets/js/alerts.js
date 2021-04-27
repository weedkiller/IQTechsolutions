/**
 * The New Article Alert Logic
 * 
 * @author Johan Ehlers
 * @since 2020/06/26
 */
$(document).ready(function () {
    "use stict";
    console.log("js/alerts.js - Update 2020/07/03 14:37");

    const addAlert = function () {
        var a = $("" +
            "<div class='alert alert-success'>" +
            "  daar loop hy" +
            "  <button type='button' class='close' data-dismiss='alert'" +
            "          aria-label='Close'><span aria-hidden='true'>&times;</span>" +
            "  </button>" +
            "</div>");
        $('#alerts .container').append(a);
        $('#alerts').addClass('has-alerts');
    };

    // addAlert();
});