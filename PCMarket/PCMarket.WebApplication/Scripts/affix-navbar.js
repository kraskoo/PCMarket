function navbarAffix() {
    $("#navbar").on("affixed.bs.affix", function (t) {
        var navTarget = t.currentTarget;
        $(navTarget).removeClass("navbar-static-top").addClass("navbar-fixed-top");
        $(navTarget).removeClass("navbar-onstatictop").addClass("navbar-onfixedtop");
        $("#nav-container").switchClass("container", "container-fluid", 1000);
        $(".navbartabs").switchClass("navbartabs-onstatic", "navbartabs-onfixed", 1000);
    });

    $("#navbar").on("affixed-top.bs.affix", function (t) {
        var navTarget = t.currentTarget;
        $(navTarget).removeClass("navbar-fixed-top").addClass("navbar-static-top");
        $(navTarget).removeClass("navbar-onfixedtop").addClass("navbar-onstatictop");
        $("#nav-container").switchClass("container-fluid", "container", 1000);
        $(".navbartabs").switchClass("navbartabs-onfixed", "navbartabs-onstatic", 1000);
    });
};

window.addEventListener("DOMContentLoaded", navbarAffix, false);