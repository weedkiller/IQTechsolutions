/**
 * The Cloud Hosting Registration Logic
 *
 * @author Johan Ehlers
 * @since 2017/10/19
 */
$(document).ready(function () {
  $('#yearLink').hide();
  $('#monthLink').hide();
  $('#loader').hide();
  $('#progress').hide();
  $('#failBar').hide();
  ('use stict');
  console.log('js/sign-up.js - Update 2020/10/29 09:23');

  // init
  var statusUrl = 'https://olympia.olympia.team/landlord/api/tenant/status';
  var reserveUrl = 'https://olympia.olympia.team/landlord/api/tenant/reserve';
  var createUrl = 'https://olympia.olympia.team/landlord/api/tenant/claim';
  var userEdit = false;
  // var statusUrl= "http://192.168.8.124:8080/landlord/api/tenant/status?tenantId=Olympia"
  // var reserveUrl = "http://192.168.8.124:8080/landlord/api/tenant/reserve?tenantId=Olympia"
  // var createUrl = "http://192.168.8.124:8080/landlord/api/tenant/claim?tenantId=Olympia"

  //  http://192.168.8.24/landlord/api/tenant/status
  // if (("" + window.location).indexOf('local') >= 0) {
  // var statusUrl = "http://olympia.olympia.local:8080/landlord/api/tenant/status";
  // var reserveUrl = "http://olympia.olympia.local:8080/landlord/api/tenant/reserve";
  // }

  // instance name logic
  var availableInstanceNames = [];
  var checkInstanceNameTimeout = null;

  var getInstanceStatus = function () {
    instanceNameIsAvailable = false;
    $.get(
      statusUrl,
      {
        name: $('#instanceName').val(),
      },
      function (data) {
        if (data.code === 'AVAILABLE') {
          $('#instanceNameLabel .badge')
            .removeClass('badge-warning badge-danger')
            .addClass('badge-success');
          availableInstanceNames.push(data.instance);
        } else {
          $('#instanceNameLabel .badge')
            .removeClass('badge-success badge-warning')
            .addClass('badge-danger');
        }
        $('#instanceNameHelp').html(data.message);
        toggleDisableOnReserveInstanceBtn();
      }
    );
  };

  $('#instanceName').on('keyup change', function () {
    if (checkInstanceNameTimeout != null) {
      window.clearTimeout(checkInstanceNameTimeout);
      checkInstanceNameTimeout = null;
    }
    var value = $(this).val();
    if (availableInstanceNames.indexOf(value) > -1) {
      $('#instanceNameLabel .badge')
        .removeClass('badge-warning badge-danger')
        .addClass('badge-success');
      $('#instanceNameHelp').html(
        'Good news, the instance name <strong>' +
          value +
          '</strong> is still available.'
      );
      toggleDisableOnReserveInstanceBtn();
      return;
    }
    if (value.trim().length > 0) {
      checkInstanceNameTimeout = window.setTimeout(getInstanceStatus, 500);
    } else {
      $('#instanceNameLabel .badge')
        .removeClass('badge-success badge-danger')
        .addClass('badge-warning');
      $('#instanceNameHelp').html('Tip: make it memorable if possible.');
    }
    toggleDisableOnReserveInstanceBtn();
  });


  
  // email address logic
  $(
    '#emailAddress,#firstName,#lastName,#password1,#privacyandterms,#username'
  ).on('keyup change select input', function () {
    var first = document.getElementById('firstName').value;
    var last = document.getElementById('lastName').value;
    var email = document.getElementById('emailAddress').value;
    var password1 = document.getElementById('password1').value;
    
    var username = document.getElementById('username').value;

    if(userEdit == false)
    {
      var first = $('#firstName').val();
      var last = $('#lastName').val();
      first = first.replaceAll("-", '.');
      last = last.replaceAll("-", '.');
      last= last.replaceAll(" ", ".");
      var user = first + "." +  last;
      user = user.replaceAll(" ", ".");
    
      $('#username').val(user);
    }
    


    if (
      validateEmail(email) &&
      validateName(first) &&
      validateName(last) &&
      validatePassword(password1) &&
      validateUsername(username)
    ) {
      $('#emailAddressLabel .badge')
        .removeClass('badge-warning')
        .addClass('badge-success');
    } else {
      $('#emailAddressLabel .badge')
        .removeClass('badge-success')
        .addClass('badge-warning');
    }


     if (
      password1.length < 6
    ) {
      document.getElementById('passwordTip').innerHTML =
      'Password must be a mininum of 6 characters';
    } else 
     {
      document.getElementById('passwordTip').innerHTML = '';
    }

    if (validateUsername(username) == false) {
      document.getElementById('emailAddressHelp').innerHTML =
        "Username must be atleast 3 characters, with ' _ - . ' allowed in the middle";
    } else if (validateUsername(username) == true) {
      document.getElementById('emailAddressHelp').innerHTML = '';
    }
    toggleDisableOnReserveInstanceBtn();
  });

  $('#pin1,#pin2,#pin3,#pin4,#pin5,#pin6').bind('paste', function (e) {
    // access the clipboard using the api
    var pastedData = e.originalEvent.clipboardData.getData('text');
    var chars = pastedData.split('');
    if (pastedData.length === 6) {
      $('#pin1').val(chars[0]);
      $('#pin2').val(chars[1]);
      $('#pin3').val(chars[2]);
      $('#pin4').val(chars[3]);
      $('#pin5').val(chars[4]);
      $('#pin6').val(chars[5]);
    }
  });

  


    $(
      '#username')
      .on('change input',function () {
      userEdit = true;
      
    })




  function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
  }

  // reserve the instance namea
  function toggleDisableOnReserveInstanceBtn() {
    console.log('toggle disable reserve instance btn');
    var first = $('#firstName').val();
    var last = $('#lastName').val();
    var instance = $('#instanceName').val();
    var emailAddress = $('#emailAddress').val();
    var password1 = $('#password1').val();
    var checkbox = document.getElementById('privacyandterms').checked;
    var username = $('#username').val();

    if (
      availableInstanceNames.indexOf(instance) > -1 &&
      validateEmail(emailAddress) &&
      validateName(first) &&
      validateName(last) &&
      validatePassword(password1) &&
      checkbox === true &&
      validateUsername(username)
    ) {

      $('#reserveInstanceBtnDefault').removeClass('btn-warning');
      $('#reserveInstanceBtnDefault').addClass('btn-success');
      $('#reserveInstanceBtnDefault').removeAttr('disabled');
      
      return true;
    } else {

      $('#reserveInstanceBtnDefault').addClass('btn-warning');
      $('#reserveInstanceBtnDefault').removeClass('btn-success');
      $('#reserveInstanceBtnDefault').attr('disabled', 'disabled');
      return false;
    }
  }

  $(
    '#reserveInstanceBtnDefault'
  ).click(function () {
    console.log('btn clicked');
    if (!toggleDisableOnReserveInstanceBtn()) {
      return false;
    } else {
      $('#emailAddress').attr('readonly', 'readonly');
      $('#instanceName').attr('readonly', 'readonly');
      $('#reserveInstanceBtn i')
        .removeClass('fa-envelope')
        .addClass('fa-pulse fa-spinner');
      $('#instanceName').prop('disabled', true);
      $('#firstName').prop('disabled', true);
      $('#lastName').prop('disabled', true);
      $('#emailAddress').prop('disabled', true);
      $('#username').prop('disabled', true);
      $('#password1').prop('disabled', true);
      reserveInstanceName();
      $('#pincode').show();
    }
  });

  $('#estimateUsers,#estimateYear, #estimateMonth').on(
    'keyup change select input',
    function () {
      var users = $('#estimateUsers').val();
      var estimateAmount = users * price;
      document.getElementById('estimateAmount').innerHTML =
        '$' + estimateAmount.toFixed(2);
    }
  );

  $('#estimateYear,#estimateMonth,#dropdownMenuButton').click(function () {
    var users = $('#estimateUsers').val();
    var estimateAmount = users * price;
    document.getElementById('estimateAmount').innerHTML =
      '$' + estimateAmount.toFixed(2);
  });

  $('#pin1,#pin2,#pin3,#pin4,#pin5,#pin6').on('input', function () {
    var instance = $('#instanceName').val();
    var emailAddress = $('#emailAddress').val();

    var pin1 = $('#pin1').val();
    var pin2 = $('#pin2').val();
    var pin3 = $('#pin3').val();
    var pin4 = $('#pin4').val();
    var pin5 = $('#pin5').val();
    var pin6 = $('#pin6').val();

    var pin = pin1 + pin2 + pin3 + pin4 + pin5 + pin6;
    var link = 'https://' + instance + '.olympia.team';
    $('#loader').hide();
    $('#failBar').hide();
    $('#progress').hide();

    //only post and begin loader once all pin boxes are full
    if (
      pin1.length === 1 &&
      pin2.length === 1 &&
      pin3.length === 1 &&
      pin4.length === 1 &&
      pin5.length === 1 &&
      pin6.length === 1
    ) {
      load = true;
      document.getElementById('successText').innerHTML = '';
      $('#pin1').prop('disabled', true);
      $('#pin2').prop('disabled', true);
      $('#pin3').prop('disabled', true);
      $('#pin4').prop('disabled', true);
      $('#pin5').prop('disabled', true);
      $('#pin6').prop('disabled', true);
      $('#progress').show();
      // loader
      width = 0;
      var timer = setInterval(function () {
        if (width !== 100 && load !== false) {
          width = width + 20;
          $('#progressBar').css('width', width + '%');
          document.getElementById('progressBar').innerHTML = width + '%';
        } else {
          load = false;
          clearInterval(timer);
          $('#loader').show();
          $('#progress').hide();
        }
      }, 5000);

      $.post(
        createUrl,
        {
          name: instance,
          emailAddress: emailAddress,
          pin: pin,
        },
        function (data) {
          //if post fails, re-enable pin blocks and reset load bar via width and clearInterval
          if (data.code !== 'SUCCESS') {
            $('#progress').hide();
            $('#failBar').show();
            $('#loader').hide();
            $('#pin1').prop('disabled', false);
            $('#pin2').prop('disabled', false);
            $('#pin3').prop('disabled', false);
            $('#pin4').prop('disabled', false);
            $('#pin5').prop('disabled', false);
            $('#pin6').prop('disabled', false);
            document.getElementById('successText').innerHTML = data.message;
            load = false;
            clearInterval(timer);
            width = 0;
          } else {
            $('#failBar').hide();
            $('#loader').hide();

            document.getElementById('successText').innerHTML = data.message;
            window.location.replace(link);
          }
        }
      );
    }
  });

  function reserveInstanceName() {
    var instance = $('#instanceName').val();
    var emailAddress = $('#emailAddress').val();
    var first = $('#firstName').val();
    var last = $('#lastName').val();
    var username = $('#username').val();
    var password = $('#password1').val();

    $.post(
      reserveUrl,
      {
        name: instance,
        emailAddress: emailAddress,
        firstName: first,
        lastName: last,
        username: username,
        password: password,
      },
      function (data) {
        $('#emailAddress').removeAttr('readonly');
        $('#instanceName').removeAttr('readonly');
        $('#reserveInstanceBtn i')
          .addClass('fa-envelope')
          .removeClass('fa-pulse fa-spinner');
        if (data.code === 'SUCCESS') {
          $('#reserveInstanceBtnLabel .badge')
            .removeClass('badge-warning')
            .addClass('badge-success');
          $('#checkYourEmailLabel .badge')
            .removeClass('badge-warning')
            .addClass('badge-success');
          $('#reserveInstanceBtnHelp').html(data.message);
        } else {
          $('#reserveInstanceBtnLabel .badge')
            .removeClass('badge-success')
            .addClass('badge-warning');
          $('#checkYourEmailLabel .badge')
            .removeClass('badge-success')
            .addClass('badge-warning');
          $('#reserveInstanceBtnHelp').html(data.message);
        }
      }
    );
  }
  function validateName(name) {
    if (name.length > 0) {
      return true;
    } else {
      return false;
    }
  }

  function validatePassword(pass) {
    if (
      pass.length > 5
    ) {
      return true;
    } else {
      return false;
    }
  }

  function validateUsername(name) {
    var re = /^(?=.{3,}$)[a-zA-Z0-9]+[a-zA-Z0-9._-]+[a-zA-Z0-9]$/;
    return re.test(name);
  }
});

function progressPlus() {
  clearInterval(timer);
  var i = 0;
  $('#progress').show();
  var timer = setInterval(function () {
    if (i !== 100) {
      i = i + 10;
      $('#progressBar').css('width', i + '%');
      document.getElementById('progressBar').innerHTML = i + '%';
    } else {
      clearInterval(timer);
      $('#loader').show();
      $('#progress').hide();
    }
  }, 3000);
}

var price = 0;
var load = false;
var width = 0;

function setEstimateMonth() {
  price = 9.99;
  document.getElementById('estimatePlan').innerHTML = 'Month';
}

function setEstimateYear() {
  price = 107.88;
  document.getElementById('estimatePlan').innerHTML = 'Annual';
}
