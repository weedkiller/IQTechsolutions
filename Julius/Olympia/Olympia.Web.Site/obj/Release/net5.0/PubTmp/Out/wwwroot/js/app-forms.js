//Index form
window.addEventListener("load", function () {
    function sendData() {
        const XHR = new XMLHttpRequest();
        const FD = new FormData(form);
        XHR.addEventListener("load", function (event) {
            alert(event.target.responseText);
        });

        XHR.addEventListener("error", function (event) {
            alert('Info Sent');
        });
        XHR.open("POST", "http://olympiahdpreview.iqtechsolutions.co.za/Support/Home/Create?returnUrl=%2F");
        XHR.send(FD);
    }
    const form = document.getElementById("indexForm");
    form.addEventListener("submit", function (event) {
        event.preventDefault();

        sendData();
    });
});

    
//contactForm
window.addEventListener("load", function () {
    function sendData() {
        const XHR = new XMLHttpRequest();
        const FD = new FormData(form);
        XHR.addEventListener("load", function (event) {
            alert(event.target.responseText);
        });

        XHR.addEventListener("error", function (event) {
            alert('Info Sent');
        });
        XHR.open("POST", "http://olympiahdpreview.iqtechsolutions.co.za/Support/Home/Create?returnUrl=%2F");
        XHR.send(FD);
    }
    const form = document.getElementById("contactForm");
    form.addEventListener("submit", function (event) {
        event.preventDefault();

        sendData();
    });
});





//Engage form
window.addEventListener("load", function () {
    function sendData() {
        const XHR = new XMLHttpRequest();
        const FD = new FormData(form);
        XHR.addEventListener("load", function (event) {
            alert(event.target.responseText);
        });
        XHR.addEventListener("error", function (event) {
            alert('Email Sent');
        });
        XHR.open("POST", "https://olympia.olympia.team/landlord/api/tenant/status", "https://olympia.olympia.team/landlord/api/tenant/reserve");
        XHR.send(FD);
    }
    const form = document.getElementById("engageForm");
    form.addEventListener("submit", function (event) {
        event.preventDefault();

        sendData();
    });
});




//Contact form
window.addEventListener("load", function () {
    function sendData() {
        const XHR = new XMLHttpRequest();
        const FD = new FormData(form);
        XHR.addEventListener("load", function (event) {
            alert(event.target.responseText);
        });
        XHR.addEventListener("error", function (event) {
            alert('Email Sent');
        });
        XHR.open("POST", "http://olympiahdpreview.iqtechsolutions.co.za/Support/Home/Create?returnUrl=%2F");
        XHR.send(FD);
    }
    const form = document.getElementById("contactForm");
    form.addEventListener("submit", function (event) {
        event.preventDefault();

        sendData();
    });
});

