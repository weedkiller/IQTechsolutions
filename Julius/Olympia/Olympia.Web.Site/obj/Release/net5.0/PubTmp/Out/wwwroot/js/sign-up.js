/**
 * The Cloud Hosting Registration Logic
 */
$(document).ready(function() {
  "use stict";

  // init
  var statusUrl = "https://olympia.olympia.team/landlord/api/tenant/status";
  var reserveUrl = "https://olympia.olympia.team/landlord/api/tenant/reserve";
  if(("" + window.location).indexOf('local') >= 0) {
    var statusUrl = "http://olympia.olympia.local:8080/landlord/api/tenant/status";
    var reserveUrl = "http://olympia.olympia.local:8080/landlord/api/tenant/reserve";
  }

  // instance name logic
  var availableInstanceNames = [];
  var checkInstanceNameTimeout = null;

  var getInstanceStatus = function() {
    instanceNameIsAvailable = false;
    $.get(statusUrl, {
      name : $("#instanceName").val()
    }, function(data) {
      if (data.code === "AVAILABLE") {
        $("#instanceNameLabel .badge").removeClass('badge-warning badge-danger').addClass('badge-success');
        availableInstanceNames.push(data.instance);
      } else {
        $("#instanceNameLabel .badge").removeClass('badge-success badge-warning').addClass('badge-danger');
      }
      $("#instanceNameHelp").html(data.message);
      toggleDisableOnReserveInstanceBtn();
    });
  };

  $("#instanceName").on("keyup change", function() {
    if (checkInstanceNameTimeout != null) {
      window.clearTimeout(checkInstanceNameTimeout);
      checkInstanceNameTimeout = null;
    }
    var value = $(this).val();
    if (availableInstanceNames.indexOf(value) > -1) {
      $("#instanceNameLabel .badge").removeClass('badge-warning badge-danger').addClass('badge-success');
      $("#instanceNameHelp").html("Good news, the instance name <strong>" + value + "</strong> is still available.");
      toggleDisableOnReserveInstanceBtn();
      return;
    }
    if (value.trim().length > 0) {
      checkInstanceNameTimeout = window.setTimeout(getInstanceStatus, 500);
    } else {
      $("#instanceNameLabel .badge").removeClass('badge-success badge-danger').addClass('badge-warning');
      $("#instanceNameHelp").html("Tip: make it memorable if possible.");
    }
    toggleDisableOnReserveInstanceBtn();
  });

  // email address logic
  $("#emailAddress").on("keyup change select input", function() {
    var value = $(this).val();
    if (validateEmail(value)) {
      $("#emailAddressLabel .badge").removeClass('badge-warning').addClass('badge-success');
    } else {
      $("#emailAddressLabel .badge").removeClass('badge-success').addClass('badge-warning');
    }
    toggleDisableOnReserveInstanceBtn();
  });

  function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
  }

  // reserve the instance name
  function toggleDisableOnReserveInstanceBtn() {
    console.log("toggle disable reserve instance btn");
    var instance = $("#instanceName").val();
    var emailAddress = $("#emailAddress").val();
    if (availableInstanceNames.indexOf(instance) > -1 && validateEmail(emailAddress)) {
      console.log('ENABLE');
      $("#reserveInstanceBtn").removeAttr('disabled');
      return true;
    } else {
      console.log('DISABLE');
      $("#reserveInstanceBtn").attr('disabled', 'disabled');
      return false;
    }
  }

  $("#reserveInstanceBtn").click(function() {
    console.log("btn clicked");
    if (!toggleDisableOnReserveInstanceBtn()) {
      return false;
    } else {
      $("#emailAddress").attr('readonly', 'readonly');
      $("#instanceName").attr('readonly', 'readonly');
      $('#reserveInstanceBtn i').removeClass('fa-envelope').addClass('fa-pulse fa-spinner');
      reserveInstanceName();
    }
  });

  function reserveInstanceName() {
    var instance = $("#instanceName").val();
    var emailAddress = $("#emailAddress").val();
    $.post(reserveUrl, {
      name : instance,
      emailAddress : emailAddress
    }, function(data) {
      $('#reserveInstanceBtn i').addClass('fa-envelope').removeClass('fa-pulse fa-spinner');
      if (data.code === "SUCCESS") {
        $("#reserveInstanceBtnLabel .badge").removeClass('badge-warning').addClass('badge-success');
        $("#reserveInstanceBtnHelp").html(data.message);
      } else {
        $("#reserveInstanceBtnLabel .badge").removeClass('badge-success').addClass('badge-warning');
        $("#reserveInstanceBtnHelp").html(data.message);
      }
    });
  }
});


//Mao


function initMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 3,
        center: { lat: -33.85531700567607, lng: 18.626526527378424 },
    });
    // Create an array of alphabetical characters used to label the markers.
    const labels = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    // Add some markers to the map.
    // Note: The code uses the JavaScript Array.prototype.map() method to
    // create an array of markers based on a given "locations" array.
    // The map() method here has nothing to do with the Google Maps API.
    const markers = locations.map((location, i) => {
        return new google.maps.Marker({
            position: location,
            label: labels[i % labels.length],
        });
    });
    // Add a marker clusterer to manage the markers.
    new MarkerClusterer(map, markers, {
        imagePath:
            "https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m",
    });
}
const locations = [
    { lat: -33.85531700567607, lng: 18.626526527378424 },
    { lat: -36.16365285979225, lng: 174.18777419858972 },
    { lat: -36.22379986280984, lng: 174.20902762895844 },
    { lat: 39.63299402791345, lng: -97.6197468971652 },
    { lat: -33.83030909570679, lng: 18.629169513884115 },
    ,

];