function load() {
    var logOffFunc = (function () {
        var logoutForm = (function () {
            return document.getElementById("logoutForm");
        }());

        var logOff = (function () {
            return document.getElementById("logOff");
        }());

        if (logOff !== null && logOff !== undefined) {
            logOff.addEventListener("click", function () {
                logoutForm.submit();
            }, false);
        }
    });

    logOffFunc();
};

window.addEventListener("DOMContentLoaded", load, false);